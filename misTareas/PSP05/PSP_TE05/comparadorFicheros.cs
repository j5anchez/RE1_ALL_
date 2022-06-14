﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace comparadorFicheros
{
    public class comparadorFicheros
    {

        public bool FileCompare(string file1, string file2)
        {
            try
            {
                int file1byte;
                int file2byte;
                FileStream fs1;
                FileStream fs2;

                if (file1 == file2)
                {
                    return true;
                }

                fs1 = new FileStream(file1, FileMode.Open);
                fs2 = new FileStream(file2, FileMode.Open);


                if (fs1.Length != fs2.Length)
                {
                    fs1.Close();
                    fs2.Close();

                    return false;
                }

                do
                {
                    file1byte = fs1.ReadByte();
                    file2byte = fs2.ReadByte();
                }
                while ((file1byte == file2byte) && (file1byte != -1));

                fs1.Close();
                fs2.Close();

                return ((file1byte - file2byte) == 0);
            }
            catch (Exception ex) { MessageBox.Show("Archivo innaccesible"); Console.WriteLine(ex.ToString()); return false; }
        }

    }
}
