using System;
using System.Collections.Generic;
using VisualBaseApp.Models;

namespace VisualBaseApp
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetAllPhotos();

        Photo GetphotoById(int id);

        void Updatephoto(Photo photo);

        void InsertPhoto(Photo photoToInsert);

        void DeletePhoto(int id);
        void DeletePhoto(Photo photo);
    }
}
