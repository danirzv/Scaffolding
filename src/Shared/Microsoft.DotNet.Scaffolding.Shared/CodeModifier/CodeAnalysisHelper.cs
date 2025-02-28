using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.MSBuild;

namespace Microsoft.DotNet.Scaffolding.Shared.CodeModifier
{
    //static class helper for CodeAnalysis 
    public static class CodeAnalysisHelper
    {
        //helps create a CodeAnalysis.Project with project files given a project path.
        public static async Task<CodeAnalysis.Project> LoadCodeAnalysisProjectAsync(
            string projectFilePath,
            IEnumerable<string> files)
        {
            var workspace = MSBuildWorkspace.Create();
            var project = await workspace.OpenProjectAsync(projectFilePath);
            var projectWithFiles = project.WithAllSourceFiles(files);
            project = projectWithFiles ?? project;
            return project;
        }        
    }
}
