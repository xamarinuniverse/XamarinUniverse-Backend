using Xunit;
using XamarinUniverse_Backend.Services;

namespace XamarinUniverse_Backend.Test.Services
{
    public class GithubFilesServiceTest
    {
        [Fact]
        public async void RepoMdToHtmlTest()
        {
            var mdToHtml = await new GithubFilesService().RepoMdToHtml("lunet-io", "markdig", "readme.md");
            Assert.NotEmpty(mdToHtml);
        }

        [Fact]
        public async void GetFileFromGithubTest()
        {
            var githubContent = await new GithubFilesService().GetFileFromGithub("lunet-io", "markdig", "readme.md");
            Assert.NotNull(githubContent);
        }



    }
}
