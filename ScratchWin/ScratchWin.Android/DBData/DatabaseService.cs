using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScratchWin.Models;
using ScratchWin.Services;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ScratchWin.Droid.DBData.DatabaseService))]

namespace ScratchWin.Droid.DBData
{
    class DatabaseService : IDBInterface
    {

        public DatabaseService()
        {
        }

        public SQLite.SQLiteConnection CreateConnection()
        {

            
            var sqliteFilename = "BdaygiftDB.db";

            string directory = Android.App.Application.Context.GetExternalFilesDir(null).ToString();
            var path = Path.Combine(directory, sqliteFilename);

            // This is where we copy in our pre-created database
            if (!File.Exists(path))
            {
                using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
                {
                    using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }
            var plat = new SQLitePlatformAndroid();
            var conn = new SQLite.SQLiteConnection(path, false);
           // conn.CreateTable<Item>();
            return conn;
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            while (bytesRead >= 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}