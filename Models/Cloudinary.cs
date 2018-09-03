using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadGeneration.Models
{
    /// <summary>
    /// Class CloudinaryImage.
    /// </summary>
    public class CloudinaryImage
    {
        /// <summary>
        /// The base URL
        /// </summary>
        public string BaseUrl;
        /// <summary>
        /// The relative path
        /// </summary>
        public string RelativePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudinaryImage" /> class.
        /// </summary>
        /// <param name="image">The image.</param>
        public CloudinaryImage(string image)
        {
            BaseUrl = Configs.Cloudinary.CloudinaryBaseUrl + "image/upload/";
            RelativePath = (image ?? "").Replace("image/upload/", "");
        }
    }
}
