﻿using Hospital.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using System.IO;

namespace Hospital
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = @"Users.sqlite";
        public static FriendAsyncRepository database;
        public static FriendAsyncRepository Database
        {
            get
            {
                if (database == null)
                {
                    // путь, по которому будет находиться база данных
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"Hospital.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database = new FriendAsyncRepository(dbPath);
                }
                return database;
            }
        }

        public static MasterDetailPage MasterDetail { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new MenuPage();
            MainPage.Navigation.PushModalAsync(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
