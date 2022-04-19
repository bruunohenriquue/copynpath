using System;
using System.IO;

namespace CopiarNPath
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileName, destFile = "";
                var destPath = File.ReadAllLines("diretorios-ctrlv.txt");
                var sourcePath = File.ReadAllLines("diretorios-ctrlc.txt");
                foreach (var destLine in destPath)
                {
                    if (System.IO.Directory.Exists(destLine))
                    {
                        foreach (var sourceLine in sourcePath)
                        {
                            if (System.IO.Directory.Exists(destLine))
                            {
                                string[] files = System.IO.Directory.GetFiles(sourceLine);
                                foreach (string s in files)
                                {
                                    // Use static Path methods to extract only the file name from the path.
                                    fileName = System.IO.Path.GetFileName(s);
                                    destFile = System.IO.Path.Combine(destLine, fileName);
                                    System.IO.File.Copy(s, destFile, true);
                                    Console.WriteLine("Copiando o arquivo: " + s + " para " + destFile);
                                }
                            }
                            else
                            {
                                Console.WriteLine("O diretório " + sourceLine + " não existe.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("O diretório " + destLine + " não existe.");
                    }
                }

                Console.WriteLine("Aperta qualquer tecla para sair.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadKey();
            }
        }
    }
}
