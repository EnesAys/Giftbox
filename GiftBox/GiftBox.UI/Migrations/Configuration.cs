namespace GiftBox.UI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GiftBox.UI.Models.GiftBoxContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GiftBox.UI.Models.GiftBoxContext context)
        {
            context.Renkler.Add(
              new DAL.Renk
              {
                  ID = 1,
                  Ad = "Kýrmýzý"
              }
              );
            context.Sekiller.Add(
                new DAL.Sekil
                {
                    ID = 1,
                    Tur = "Kalp",
                    ResimPath = "Sekiller/67f9c268-9009-485c-bf79-f744a2724414.jpg"
                }
                );
            context.Kutular.Add(
                new DAL.Kutu
                {
                    ID = 1,
                    RenkID = 1,
                    SekilID = 1
                }
                );
            context.Cicekler.Add(
                new DAL.Cicek {
                    ID=1,
                    Ad="Gül",
                    RenkID=1,
                    Fiyat=10,
                    ResimPath = "Cicek/20e0811e-7b92-4e62-8364-5c5de51701e8.jpg"
                }
                );
            context.Cikolatalar.Add(
            new DAL.Cikolata
            {
                ID = 1,
                Ad="Nutella",
                Fiyat=10,
                ResimPath= "Cikolata/6465f4b9-e4d4-4667-aced-c698e8d536f9.jpg"
            }
            );
        }
    }
}
