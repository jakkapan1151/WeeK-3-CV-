/*
using System;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace imgproc1
{
    public partial class Form1 : Form
    {
        int m = 9;

        public Form1()
        {
            InitializeComponent();

            // Ensure PictureBox and Button are properly named and declared
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Update button text
            btnClick.Text = m.ToString();

            // Load the image
            string filepath = "D:\\เรียนปี3\\เทอม2\\cv\\images.png";
            Image<Rgb, byte> myimage = new Image<Rgb, byte>(filepath);

            // Convert to grayscale
            Image<Gray, float> source = myimage.Convert<Gray, float>();

            // Clone the source image to create the result image
            Image<Gray, float> result = source.Clone();

            int omegas = 3;
            float svalue;
            float[] pop = new float[(2 * omegas + 1) * (2 * omegas + 1)];

            // Apply a median filter manually
            for (int y = omegas; y < myimage.Height - omegas; y++)
            {
                for (int x = omegas; x < myimage.Width - omegas; x++)
                {
                    float mean_value = 0.0f;
                    float median;
                    for (int n = -omegas; n <= omegas; n++)
                    {
                        for (int m = -omegas; m <= omegas; m++)
                        {
                            svalue = source.Data[y + n, x + m, 0];
                            pop[(n + omegas) * (2 * omegas + 1) + (m + omegas)] = svalue;
                            mean_value += svalue;
                        }
                    }
                    Array.Sort(pop);
                    median = pop[pop.Length / 2];
                    result.Data[y, x, 0] = median;
                }
            }

            // Display the result in the PictureBox
            Picture.Image = result.ToBitmap();
        }
    }
}
*/


/*
using System;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace imgproc1
{
    public partial class Form1 : Form
    {
        int m = 9;

        public Form1()
        {
            InitializeComponent();
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Update button text
            btnClick.Text = m.ToString();

            // Load the image
            string filepath = "D:\\เรียนปี3\\เทอม2\\cv\\images.png";
            try
            {
                Image<Rgb, byte> myimage = new Image<Rgb, byte>(filepath);

                // Convert to grayscale
                Image<Gray, byte> grayImage = myimage.Convert<Gray, byte>();

                // Apply median filter using Emgu CV's built-in method
                Image<Gray, byte> result = new Image<Gray, byte>(grayImage.Size);
                CvInvoke.MedianBlur(grayImage, result, 5); // 3 is the kernel size, which can be adjusted

                // Display the result in the PictureBox
                Picture.Image = result.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading or processing image: {ex.Message}");
            }
        }
    }
}
*/


/*
using System;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace imgproc1
{
    public partial class Form1 : Form
    {
        int m = 9;

        public Form1()
        {
            InitializeComponent();

            // Ensure PictureBox and Button are properly named and declared
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Update button text
            btnClick.Text = m.ToString();

            // Load the image
            string filepath = "D:\\เรียนปี3\\เทอม2\\cv\\images.png";
            Image<Rgb, byte> myimage = new Image<Rgb, byte>(filepath);

            

            

            ConvolutionKernelF avgkernel = new ConvolutionKernelF(new float[,] {
                { 1.0f/9.0f ,1.0f/9.0f ,1.0f/9.0f},
                { 1.0f/9.0f ,1.0f/9.0f ,1.0f/9.0f},
                { 1.0f/9.0f ,1.0f/9.0f ,1.0f/9.0f},
            });

            // Convert to grayscale
            Image<Gray, float> source = myimage.Convert<Gray, float>();

            // Clone the source image to create the result image
            Image<Gray, float> result = source.Convolution(avgkernel);



            // Display the result in the PictureBox
            Picture.Image = result.ToBitmap();
        }
    }
}

*/


/*

using System;
using System.Diagnostics.Tracing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace imgproc1
{
    public partial class Form1 : Form
    {
        int m = 9;

        public Form1()
        {
            InitializeComponent();

            // Ensure PictureBox and Button are properly named and declared
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Update button text
            btnClick.Text = m.ToString();

            Image<Rgb, byte> myimage;

            // Load the image
            string filepath = "D:\\เรียนปี3\\เทอม2\\cv\\porasit.jpg";
            myimage = new Image<Rgb,byte> (filepath);

            Image<Gray, float> source = myimage.Convert <Gray, float>();
            Image<Gray,float> gx, gy;

            gx = source.Sobel(1,0,3);
            gy = source.Sobel(0, 1, 3);




            // Display the result in the PictureBox
            Picture.Image = gx.ToBitmap();
        }
    }
}
*/


/* //ต้องเพิ่มลูปเอง

using System;
using System.Diagnostics.Tracing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace imgproc1
{
    public partial class Form1 : Form
    {
        int m = 9;

        public Form1()
        {
            InitializeComponent();

            // Ensure PictureBox and Button are properly named and declared
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Update button text
            btnClick.Text = m.ToString();

            Image<Rgb, byte> myimage;

            // Load the image
            string filepath = "D:\\เรียนปี3\\เทอม2\\cv\\porasit.jpg";
            myimage = new Image<Rgb, byte>(filepath);

            Image<Gray, float> source = myimage.Convert<Gray, float>();
            Image<Gray, float> gx, gy;

            float[] grad = { 0,0};
            float[,,] mag = new float[source.Height, source.Width, 1];
            Image<Gray, float> theta = new Image<Gray, float>(source.Size);
            Image<Gray, float> imag;
            Image<Rgb, float> vgrad = new Image<Rgb, float>(source.Size);

            gx = source.Sobel(1, 0, 3);
            gy = source.Sobel(0, 1, 3);

            int x = 20, y = 100;

            grad[0] = gx.Data[y, x, 0];
            grad[1] = gy.Data[y, x, 0];

            for (x, y)
                grad[0] = gx.Data[y,x,0];
                grad[1] = gy.Data[y, x, 0];
                mag[y, x,0] = (float)Math.Sqrt(grad[0] * grad[0] + grad[1] * grad[1]);
                theta.Data[y, x, 0] = (float)Math.Atan2(grad[1], grad[0]);
                vgrad.Data[y, x, 0] = gx.Data[x, y, 0];
                vgrad.Data[y, x, 1] = gy.Data[x, y, 0];
                vgrad.Data[y, x, 2] = theta.Data[x, y, 0];

            imag = new Image<Gray, float>(mag);
            Image<Gray, byte> result = vgrad.Canny(100, 300);
            // Display the result in the PictureBox
            Picture.Image = gx.ToBitmap();
        }
    }
}

*/


/*

//เพิ่มลูปเสร็จแล้ว

using System;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace imgproc1
{
    public partial class Form1 : Form
    {
        int m = 9;

        public Form1()
        {
            InitializeComponent();
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnClick.Text = m.ToString();

            // Load the image
            string filepath = "D:\\เรียนปี3\\เทอม2\\cv\\banner_file.jpg";
            Image<Rgb, byte> myimage = new Image<Rgb, byte>(filepath);

            // Convert image to grayscale
            Image<Gray, float> source = myimage.Convert<Gray, float>();

            // Sobel gradients
            Image<Gray, float> gx = source.Sobel(1, 0, 3);
            Image<Gray, float> gy = source.Sobel(0, 1, 3);

            // Initialize magnitude and direction arrays
            float[,,] mag = new float[source.Height, source.Width, 1];
            Image<Gray, float> theta = new Image<Gray, float>(source.Size);
            Image<Rgb, float> vgrad = new Image<Rgb, float>(source.Size);

            // Loop through each pixel
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    // Compute gradients at (x, y)
                    float gradX = gx.Data[y, x, 0];
                    float gradY = gy.Data[y, x, 0];

                    // Compute magnitude and direction
                    mag[y, x, 0] = (float)Math.Sqrt(gradX * gradX + gradY * gradY);
                    theta.Data[y, x, 0] = (float)Math.Atan2(gradY, gradX);

                    // Visualize gradient components (optional)
                    vgrad.Data[y, x, 0] = gradX;
                    vgrad.Data[y, x, 1] = gradY;
                    vgrad.Data[y, x, 2] = theta.Data[y, x, 0];
                }
            }

            // Create magnitude image from computed values
            Image<Gray, float> imag = new Image<Gray, float>(mag);

            // Display the result in the PictureBox
            Picture.Image = imag.ToBitmap();
        }
    }
}

*/






/*

//canny
using System;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace imgproc1
{
    public partial class Form1 : Form
    {
        int m = 9;

        public Form1()
        {
            InitializeComponent();
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnClick.Text = m.ToString();

            // Load the image
            string filepath = "D:\\เรียนปี3\\เทอม2\\cv\\banner_file.jpg";
            Image<Rgb, byte> myimage = new Image<Rgb, byte>(filepath);

            // Convert image to grayscale
            Image<Gray, float> source = myimage.Convert<Gray, float>();

            // Sobel gradients
            Image<Gray, float> gx = source.Sobel(1, 0, 3);
            Image<Gray, float> gy = source.Sobel(0, 1, 3);

            // Initialize magnitude and direction arrays
            float[,,] mag = new float[source.Height, source.Width, 1];
            Image<Gray, float> theta = new Image<Gray, float>(source.Size);

            // Loop through each pixel
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    // Compute gradients at (x, y)
                    float gradX = gx.Data[y, x, 0];
                    float gradY = gy.Data[y, x, 0];

                    // Compute magnitude and direction
                    mag[y, x, 0] = (float)Math.Sqrt(gradX * gradX + gradY * gradY);
                    theta.Data[y, x, 0] = (float)Math.Atan2(gradY, gradX);
                }
            }

            // Create magnitude image from computed values
            Image<Gray, float> imag = new Image<Gray, float>(mag);

            // Convert magnitude image to 8-bit
            Image<Gray, byte> imag8bit = imag.Convert<Gray, byte>();

            // Apply Canny edge detection
            Image<Gray, byte> edges = imag8bit.Canny(100, 200);

            // Display the Canny edge detection result in the PictureBox
            Picture.Image = edges.ToBitmap();
        }
    }
}
*/



using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace imgproc1
{
    public partial class Form1 : Form
    {
        private Rectangle selectionRectangle;
        private bool isSelecting = false;

        private Image<Rgb, byte> originalImage;
        private Image<Gray, float> source;
        private Image<Gray, float> magnitude;

        public Form1()
        {
            InitializeComponent();
            Picture.SizeMode = PictureBoxSizeMode.Zoom;

            // Initialize DataGridView
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "X";
            dataGridView1.Columns[1].Name = "Y";
            dataGridView1.Columns[2].Name = "||G||";

            // Add mouse event handlers
            Picture.MouseDown += Picture_MouseDown;
            Picture.MouseMove += Picture_MouseMove;
            Picture.MouseUp += Picture_MouseUp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the image
            string filepath = "D:\\เรียนปี3\\เทอม2\\cv\\week3\\week3Sobel2.bmp";
            originalImage = new Image<Rgb, byte>(filepath);

            // Convert image to grayscale
            source = originalImage.Convert<Gray, float>();

            // Define custom Sobel kernels
            float[,] sobelXKernel = new float[,]
            {
                { -1,  0,  1 },
                { -2,  0,  2 },
                { -1,  0,  1 }
            };

            float[,] sobelYKernel = new float[,]
            {
                { -1, -2, -1 },
                {  0,  0,  0 },
                {  1,  2,  1 }
            };

            // Apply custom Sobel kernels
            var gx = ApplyCustomKernel(source, sobelXKernel);
            var gy = ApplyCustomKernel(source, sobelYKernel);

            // Compute gradient magnitude
            magnitude = new Image<Gray, float>(source.Size);
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    float gradX = gx.Data[y, x, 0];
                    float gradY = gy.Data[y, x, 0];
                    magnitude.Data[y, x, 0] = (float)Math.Sqrt(gradX * gradX + gradY * gradY);
                }
            }

            Picture.Image = originalImage.ToBitmap();
        }

        private Image<Gray, float> ApplyCustomKernel(Image<Gray, float> image, float[,] kernelData)
        {
            // Convert the kernel array to an EmguCV Matrix
            var kernel = new Emgu.CV.Matrix<float>(kernelData);

            // Output image
            var result = new Image<Gray, float>(image.Size);

            // Apply the custom kernel
            CvInvoke.Filter2D(image, result, kernel, new Point(-1, -1));

            return result;
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            isSelecting = true;
            selectionRectangle = new Rectangle(e.Location, new Size(0, 0));
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                selectionRectangle.Width = e.X - selectionRectangle.X;
                selectionRectangle.Height = e.Y - selectionRectangle.Y;
                Picture.Refresh();
                using (Graphics g = Picture.CreateGraphics())
                {
                    g.DrawRectangle(Pens.Red, selectionRectangle);
                }
            }
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            isSelecting = false;

            // Map the selected rectangle to image coordinates
            var imageScale = new SizeF(
                (float)originalImage.Width / Picture.ClientSize.Width,
                (float)originalImage.Height / Picture.ClientSize.Height);
            var roi = new Rectangle(
                (int)(selectionRectangle.X * imageScale.Width),
                (int)(selectionRectangle.Y * imageScale.Height),
                (int)(selectionRectangle.Width * imageScale.Width),
                (int)(selectionRectangle.Height * imageScale.Height));

            // Ensure ROI is within image bounds
            roi.Intersect(new Rectangle(0, 0, source.Width, source.Height));

            // Extract data in ROI and find top 100 magnitudes
            var magnitudes = new List<(int X, int Y, float Magnitude)>();
            for (int y = roi.Top; y < roi.Bottom; y++)
            {
                for (int x = roi.Left; x < roi.Right; x++)
                {
                    magnitudes.Add((x, y, magnitude.Data[y, x, 0]));
                }
            }

            var topMagnitudes = magnitudes
                .OrderByDescending(m => m.Magnitude)
                .Take(100)
                .ToList();

            // Create a binary image for the ROI
            var binaryImage = new Image<Gray, byte>(source.Size);
            binaryImage.SetValue(0); // Set entire image to black

            // Set top 100 gradient magnitude pixels in the ROI to white
            foreach (var mag in topMagnitudes)
            {
                binaryImage.Data[mag.Y, mag.X, 0] = 255;
            }

            // Create a mask for the ROI
            var maskedBinaryImage = new Image<Gray, byte>(binaryImage.Size);
            maskedBinaryImage.SetValue(0);

            for (int y = roi.Top; y < roi.Bottom; y++)
            {
                for (int x = roi.Left; x < roi.Right; x++)
                {
                    maskedBinaryImage.Data[y, x, 0] = binaryImage.Data[y, x, 0];
                }
            }

            // Display the binary image with ROI adjustment in the PictureBox
            Picture.Image = maskedBinaryImage.ToBitmap();

            // Display top magnitudes in DataGridView
            dataGridView1.Rows.Clear();
            foreach (var mag in topMagnitudes)
            {
                dataGridView1.Rows.Add(mag.X, mag.Y, mag.Magnitude.ToString("F2"));
            }
        }


    }
}


