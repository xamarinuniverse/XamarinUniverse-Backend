using Markdig;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinUniverse_Backend.Models;
using XamarinUniverse_Backend.Utils;

namespace XamarinUniverse_Backend.Services
{
    public class GithubFilesService: IGithubFilesService
    {
        
        public async Task<string> RepoMdToHtml(string owner, string repo, string path)
        {
            var file = await GetFileFromGithub(owner, repo, path);
            if (file.Name.Split(".").LastOrDefault().ToLower()!="md")
            {
                throw new NotMdException();
            }
            var md = FileToString(file);
            return Markdown.ToHtml(md);
        }
        
        public async Task<GithubResponse> GetFileFromGithub(string owner, string repo, string path)
        {
            var response = await GetGithubContent(owner, repo, path);
            return JsonConvert.DeserializeObject<GithubResponse>(await response.Content.ReadAsStringAsync());
        }
        private Task<HttpResponseMessage> GetGithubContent(string owner, string repo, string path)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "request");
            return client.GetAsync($"https://api.github.com/repos/{owner}/{repo}/contents/{path}");
        }
        private string FileToString(GithubResponse response)
        {
            byte[] bytesContent = Convert.FromBase64CharArray(response.Content.ToCharArray(), 0, response.Content.Length);
            var result = Encoding.UTF8.GetString(bytesContent);
            return result;
        }
    }
}
