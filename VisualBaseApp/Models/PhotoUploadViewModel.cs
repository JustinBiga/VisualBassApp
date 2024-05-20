using System;
using System.Collections.Generic;

namespace VisualBaseApp.Models
{
        public class PhotoUploadViewModel
        {
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? FilePath { get; set; }
            public IFormFile? PhotoFile { get; set; }
        }
}

