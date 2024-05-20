//using System;
//using MySql.Data.MySqlClient;

//namespace VisualBaseApp.Models
//{
//	public class DatabaseUtility
//    {
//        private static string _connectionString;

//        static DatabaseUtility()
//        {
//            var builder = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//            var configuration = builder.Build();
//            _connectionString = configuration.GetConnectionString("DefaultConnection");
//        }

//        public static List<Photo> GetPhotos()
//        {
//            var photos = new List<Photo>();

//            using (var connection = new MySqlConnection(_connectionString))
//            {
//                connection.Open();

//                var query = "SELECT Id, Title, FilePath FROM Photos";
//                using (var command = new MySqlCommand(query, connection))
//                {
//                    using (var reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            var photo = new Photo
//                            {
//                                Id = reader.GetInt32("Id"),
//                                Title = reader.GetString("Title"),
//                                FilePath = reader.GetString("FilePath"),
//                                ImageData = new List<ImageData>()
//                            };

//                            photos.Add(photo);
//                        }
//                    }
//                }
//            }

//            return photos;
//        }
//    }
//}

