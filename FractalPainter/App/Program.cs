﻿using System;
using System.Windows.Forms;
using FractalPainting.App.Actions;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Ninject;
using Ninject.Extensions.Factory;



namespace FractalPainting.App
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                IKernel kernel = new StandardKernel();
                kernel.Bind<IUiAction>().To<SaveImageAction>();
                kernel.Bind<IUiAction>().To<DragonFractalAction>();
                kernel.Bind<IUiAction>().To<KochFractalAction>();
                kernel.Bind<IUiAction>().To<ImageSettingsAction>();
                kernel.Bind<IUiAction>().To<PaletteSettingsAction>();
                kernel.Bind<IImageHolder, PictureBoxImageHolder>().To<PictureBoxImageHolder>().InSingletonScope();
                kernel.Bind<Palette>().ToSelf().InSingletonScope();

                kernel.Bind<IDragonPainterFactory>().ToFactory();

                Application.Run(kernel.Get<MainForm>());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}