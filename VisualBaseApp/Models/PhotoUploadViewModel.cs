using System;
using System.Collections.Generic;

namespace VisualBaseApp.Models
{
    public class PhotoUploadViewModel
    {
        public int Id { get; set; }
        public string? Title{ get; set; }
        public string? Description { get; set; }
        public IFormFile? PhotoFile { get; set; }
        public string? FilePath { get; internal set; }
    }

    //public class ApplicationDbContext : DbContext
    //{
    //    public DbSet<Photo>? Photos { get; set; }
    //    public DbSet<ImageData>? ImageData { get; set; }

    //    // Constructor and other methods
    //}

    //public class DbContext
    //{
    //}

    //public class DbSet<T>
    //{
    //}
}

