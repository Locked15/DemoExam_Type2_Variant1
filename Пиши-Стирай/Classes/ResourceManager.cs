using System;
using System.IO;

namespace Пиши_Стирай.Classes
{
    public static class ResourceManager
    {
        public static String PathToProject { get; private set; }

        static ResourceManager()
        {
            String path = Environment.CurrentDirectory;
            path = Directory.GetParent(path).Parent.FullName;

            PathToProject = path;
        }

        public static String GetSafeImage(String imageName)
        {
            String path = Path.Combine(PathToProject, "Resources", imageName ?? String.Empty);

            if (File.Exists(path))
                return path;

            else
                return Path.Combine(PathToProject, "Resources", "!Picture.png");
        }
    }
}
