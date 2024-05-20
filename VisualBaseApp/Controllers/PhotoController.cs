using System.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using VisualBaseApp.Models;

namespace VisualBaseApp.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoRepository repo;
        private readonly object _context;
        private readonly string connectionString;

        //private readonly object _context;
        //private readonly MyDbContext _dbContext;

        //public PhotoController(MyDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public PhotoController(IPhotoRepository repo)
        {
            this.repo = repo;
        }
        // GET: Photo
        public IActionResult Index()
        {
            var photos = repo.GetAllPhotos();
            return View(photos);
        }

        // GET: Photo/Create
        public IActionResult Insert()
        {
            return View();
        }

        // POST: Photo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertPhotoToDatabase(Photo photoToInsert)
        {
            repo.InsertPhoto(photoToInsert);

            return RedirectToAction("Index");
        }

        // GET: Photo/Edit/5
        public IActionResult Updatephoto(int id)
        {
            Photo photo = repo.GetphotoById(id);
            if (photo == null)
            {
                return View("PhotoNotFound");
            }
            return View(photo);
        }

        public IActionResult UpdatePhotoToDatabase(Photo photo)
        {
            repo.Updatephoto(photo);

            return RedirectToAction("viewPhoto", new { id = photo.Id });
        }

        // GET: Photo/Delete/5
        public IActionResult Delete(int id)
        {
            var photo = repo.GetphotoById(id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }
        public IActionResult DeletePhoto(Photo photo)
        {
            repo.DeletePhoto(photo);
            return RedirectToAction("Index");
        }
        // POST: Photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewPhoto(int id)
        {
            var photo = repo.GetphotoById(id);
            return View(photo);
        }
        //[HttpPost]
        //public IActionResult Create(PhotoUploadViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string query = "INSERT INTO Photos (Title, FilePath) VALUES (@Title, @FilePath); SELECT LAST_INSERT_ID();";
        //        List<MySqlParameter> parameters = new List<MySqlParameter>
        //        {
        //            new MySqlParameter("@Title", model.Title),
        //            new MySqlParameter("@FilePath", model.FilePath)
        //        };

        //        int photoId = ExecuteNonQuery(query, parameters);
        //        // Save the image data
        //        if (model.PhotoFile != null)
        //        {
        //            using (var memoryStream = new MemoryStream())
        //            {
        //                model.PhotoFile.CopyTo(memoryStream);
        //                byte[] imageBytes = memoryStream.ToArray();

        //                query = "INSERT INTO ImageData (PhotoId, ImageBytes) VALUES (@PhotoId, @ImageBytes)";
        //                parameters = new List<MySqlParameter>
        //        {
        //            new MySqlParameter("@PhotoId", photoId),
        //            new MySqlParameter("@ImageBytes", imageBytes)
        //        };

        //                ExecuteNonQuery(query, parameters);
        //            }
        //        }

        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(model);
        //}

        public int ExecuteNonQuery(string query, List<MySqlParameter> parameters)
        {
            using var connection = GetConnection();
            connection.Open();
            using var command = new MySqlCommand(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }
            return command.ExecuteNonQuery();
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }


        //public IActionResult GetImage(int id)
        //{
        //    var imageData = _context.ImageData.FirstOrDefault(i => i.Id == id);
        //    if (imageData != null)
        //    {
        //        return File(imageData.ImageBytes, "image/jpeg");
        //    }

        //    return NotFound();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(PhotoUploadViewModel model)
        //{
        //if (ModelState.IsValid)
        //{
        //    // Save the photo data to the database
        //    var photo = new Photo
        //    {
        //        Title = model.Title,
        //        FilePath = model.FilePath,
        //        ImageData = new List<ImageData>()
        //    };

        //    if (model.PhotoFile != null)
        //    {
        //        var fileName = Path.GetFileName(model.PhotoFile.FileName);
        //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "create", fileName);

        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await model.PhotoFile.CopyToAsync(stream);
        //        }

        //        // Save other data to the database
        //        // ...
        //    }

        //    return RedirectToAction(nameof(Index));
        //}

        //    return View(model);

        [HttpPost]
        public async Task<IActionResult> Upload(PhotoUploadViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    // Save the photo data to the database
                    var photo = new Photo
                    {
                        Title = model.Title,
                        FilePath = model.FilePath,
                        ImageData = new List<ImageData>()
                    };
                }
                // Process the uploaded photo file
                if (model.PhotoFile != null)
                {
                    var fileName = Path.GetFileName(model.PhotoFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.PhotoFile.CopyToAsync(stream);
                    }

                    // Save other data to the database
                    // ...
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}