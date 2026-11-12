using NeonWindows.UI.Windowing;
using System;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;

namespace NeonWindows.UI.Modern.Xaml.Desktop;

public partial class WindowsXamlHostBase
{
    /// <summary>
    /// Last Focus Request GUID to uniquely identify Focus operations, primarily used with error callbacks
    /// </summary>
    private Guid _lastFocusRequest = Guid.Empty;

    private bool _forceFocusNavigation = false;

    public override bool Focused
    {
        get
        {
            if (!IsHandleCreated) return false;
            // Get currently focused window handle and compare with Control
            // and hosted Xaml content window handles
            return WindowFocus.GetFocus().Handle == Handle || (XamlSourceWin32Window is not null && XamlSourceWin32Window.Handle != default && windowXamlSource.HasFocus);
        }
    }

    protected override void Select(bool directed, bool forward)
        => ProcessTabKey(forward);

    /// <summary>
    /// Processes a tab key, ensuring that Xaml has an opportunity
    /// to handle the command before normal Windows Forms processing.
    /// (Xaml must be notified of keys that invoke focus navigation.)
    /// </summary>
    /// <returns>true if the command was processed</returns>
    protected override bool ProcessTabKey(bool forward)
    {
        if (ComponentHelper.IsDesigntime) return false;
        // Determine if the currently focused element is the last element for the requested
        // navigation direction.  If the currently focused element is not the last element
        // for the requested navigation direction, navigate focus to the next focusable
        // element.
        if (!windowXamlSource.HasFocus || _forceFocusNavigation)
        {
            _forceFocusNavigation = false;
            XamlSourceFocusNavigationRequest request = new(forward ? XamlSourceFocusNavigationReason.First : XamlSourceFocusNavigationReason.Last, default);
            _lastFocusRequest = request.CorrelationId;
            return windowXamlSource.NavigateFocus(request).WasFocusMoved;
        }
        else
        {
            // Call FocusManager.TryMoveFocus Next or Previous and return
            FocusNavigationDirection navigationDirection = forward ? FocusNavigationDirection.Next : FocusNavigationDirection.Previous;
            return FocusManager.TryMoveFocus(navigationDirection);
        }
    }

    /// <summary>
    /// Responds to DesktopWindowsXamlSource TakeFocusRequested event
    /// </summary>
    /// <param name="sender">DesktopWindowsXamlSource</param>
    /// <param name="args">DesktopWindowXamlSourceTakeFocusRequestedEventArgs</param>
    private void OnTakeFocusRequested(DesktopWindowXamlSource sender, DesktopWindowXamlSourceTakeFocusRequestedEventArgs args)
    {
        if (_lastFocusRequest == args.Request.CorrelationId)
        {
            // If we've arrived at this point, then focus is being move back to us
            // therefore, we should complete the operation to avoid an infinite recursion
            // by "Restoring" the focus back to us under a new correlationId
            XamlSourceFocusNavigationRequest newRequest = new(XamlSourceFocusNavigationReason.Restore);
            windowXamlSource.NavigateFocus(newRequest);
            _lastFocusRequest = newRequest.CorrelationId;
        }
        else
        {
            // Focus was not initiated by WindowsXamlHost. Continue processing the Focus request.
            XamlSourceFocusNavigationReason reason = args.Request.Reason;
            if (reason == XamlSourceFocusNavigationReason.First || reason == XamlSourceFocusNavigationReason.Last)
            {
                _forceFocusNavigation = true;
                try
                {
                    Parent?.SelectNextControl(this, reason == XamlSourceFocusNavigationReason.First, tabStopOnly: true, nested: false, wrap: true);
                }
                finally
                {
                    _forceFocusNavigation = false;
                }
            }
        }
    }
}
