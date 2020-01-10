using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


namespace list
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //将List<double> 转为 byte[]
        static byte[] ConvertDoubleArrayToBytes(List<double> matrix)
        {
            if (matrix == null)
            {
                return new byte[0];
            }
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(stream);
                foreach (var item in matrix)
                {
                    bw.Write(item);
                }
                return stream.ToArray();
            }
        }
        //将byte[] 转为 List<double>
        static List<double> ConvertBytesToDoubleArray(byte[] matrix)
        {
            if (matrix == null)
                return null;

            List<double> result = new List<double>();
            using (var br = new BinaryReader(new MemoryStream(matrix)))
            {
                var ptCount = matrix.Length / 8;
                for (int i = 0; i < ptCount; i++)
                {
                    result.Add(br.ReadDouble());
                }
                return result;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<double> data = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0 };
            byte[] bdata = ConvertDoubleArrayToBytes(data);
            data = ConvertBytesToDoubleArray(bdata);
            foreach (var item in data)
            {
                listBox1.Items.Add(item);
            }
           

        }
    }
}
