using NHCM.Persistence.FileHandler;

namespace Cropper.Models
{
    public class CropRequest:File
    {
        /// <summary>
        /// your image path (the one we recieved after successfull upload)
        /// </summary>
        //[Alias("imgUrl")]
        public string imgUrl { get; set; }

        // <summary>
        // your image original width(the one we recieved after upload)
            /// </summary>
           // [Alias("imgInitW")]
        public int imgInitW { get; set; }

        /// <summary>
        /// your image original height (the one we recieved after upload)
        /// </summary>
        //[Alias("imgInitH")]
        public int imgInitH { get; set; }

        /// <summary>
        /// your new scaled image width
        /// </summary>
        //[Alias("imgW")]
        public double imgW { get; set; }

        /// <summary>
        /// your new scaled image height
        /// </summary>
       // [Alias("imgH")]
        public double imgH { get; set; }

        /// <summary>
        /// top left corner of the cropped image in relation to scaled image
        /// </summary>
        //[Alias("imgX1")]
        public int imgX1 { get; set; }

        /// <summary>
        /// top left corner of the cropped image in relation to scaled image
        /// </summary>
       // [Alias("imgY1")]
        public int imgY1 { get; set; }

        /// <summary>
        /// cropped image width
        /// </summary>
        //[Alias("cropW")]
        public double cropW { get; set; }

        /// <summary>
        /// cropped image height
        /// </summary>
       // [Alias("cropH")]
        public double cropH { get; set; }
    }
}
