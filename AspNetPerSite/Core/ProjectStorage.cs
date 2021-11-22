using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetPerSite.Core
{
    public static class ProjectStorage
    {
        public static List<Project> Projects { get; private set; } = new List<Project>();

        public static void Add(Project project)
        {
            Projects.Add(project);
        }

        public static void RemoveByName(string name)
        {
            Projects.RemoveAll(p => p.Name == name);
        }
    }
}
