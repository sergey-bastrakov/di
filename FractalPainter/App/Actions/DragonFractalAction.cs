using System;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;
using FractalPainting.Infrastructure.UiActions;
using Ninject;

namespace FractalPainting.App.Actions
{
    public class DragonFractalAction : IUiAction
	{
	    private readonly IDragonPainterFactory painterFactory;

	    public DragonFractalAction(IDragonPainterFactory painterFactory)
	    {
	        this.painterFactory = painterFactory;
	    }

		public string Category => "Фракталы";
		public string Name => "Дракон";
		public string Description => "Дракон Хартера-Хейтуэя";

		public void Perform()
		{
			var dragonSettings = CreateRandomSettings();
			// редактируем настройки:
			SettingsForm.For(dragonSettings).ShowDialog();
            // создаём painter с такими настройками
		    painterFactory.Create(dragonSettings).Paint();
        }

		private static DragonSettings CreateRandomSettings()
		{
			return new DragonSettingsGenerator(new Random()).Generate();
		}
	}
}