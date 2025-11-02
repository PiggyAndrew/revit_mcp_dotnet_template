using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using Tuna.Revit.Extensions;

namespace NET.App.Revit;

/// <summary>
/// Main application class for the Revit Drainage System plugin
/// Responsible for initializing plugin interface and functionality
/// </summary>
public class App : IExternalApplication
{
    public static Tuna.Revit.Extensions.IExternalEventService _externalEvent; 
    /// <summary>
    /// Create bitmap image from image name
    /// </summary>
    /// <param name="image">Image filename</param>
    /// <returns>Bitmap image object for Ribbon interface</returns>
    private BitmapImage CreateBitmapImageByURI(string image)
    {
        return new BitmapImage(new Uri($"pack://application:,,,/NET.App.Revit;component/Assets/icon/{image}"));
    }

    /// <summary>
    /// Initialize Ribbon interface
    /// Create plugin tabs, panels and buttons
    /// </summary>
    /// <param name="application">Revit UI application object</param>
    private void RibbonInitialize(UIControlledApplication application)
    {
        IRibbonTab ribbonTab = application.AddRibbonTab("AI");

        ribbonTab.AddRibbonPanel("AI", panel =>
        {
            panel.AddPushButton<Commands.RevitSocketServerCommand>(data =>
               data.LargeImage = CreateBitmapImageByURI("mass.png"));
            panel.AddPushButton<Commands.StopSocketServerCommand>(data =>
               data.LargeImage = CreateBitmapImageByURI("mass.png"));
        });
    }


    public Result OnStartup(UIControlledApplication application)
    {
        RibbonInitialize(application);
        GetExternalEventService();
        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }


    private Tuna.Revit.Extensions.IExternalEventService GetExternalEventService()
    {
        if (_externalEvent == null)
        {
            _externalEvent = new ExternalEventService();
        }
        return _externalEvent;
    }
}
