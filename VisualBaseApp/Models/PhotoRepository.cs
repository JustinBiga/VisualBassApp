using Dapper;
using VisualBaseApp.Models;
using System.Data;

namespace VisualBaseApp
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IDbConnection _connection;

        public PhotoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            return _connection.Query<Photo>("SELECT * FROM Photos");
        }

        public void InsertPhoto(Photo photoToInsert)
        {
            _connection.Execute(@"INSERT INTO Photos (Title, Description, FilePath) 
                                    VALUES (@Title, @Description, @FilePath)", photoToInsert);
        }

        public Photo GetphotoById(int id)
        {
            return _connection.QuerySingle<Photo>("SELECT * FROM Photos WHERE Id = @Id", new { Id = id });
        }
        public void Updatephoto(Photo photo)
        {
            _connection.Execute("UPDATE Photos  SET Title = @title, Description = @description, FilePath = @filepath  WHERE Id = @id",
                new {title = photo.Title, description = photo.Description, filepath = photo.FilePath, id = photo.Id});
        }

        public void DeletePhoto(int id)
        {
            _connection.Execute("DELETE FROM Photos WHERE Id = @Id", new { Id = id });
        }
        public void DeletePhoto(Photo photo)
        {
            _connection.Execute("DELETE FROM Photos WHERE Id = @id;", new { id = photo.Id });
        }
    }
}
