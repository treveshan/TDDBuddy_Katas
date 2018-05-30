using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPlayGroundTemplate
{
    public class UrlHelper
    {
        private readonly Dictionary<string, string> _defaultPorts = new Dictionary<string, string>()
        {
            {"http","80" },
            {"https","443" },
            {"ftp","21" },
            {"ftps","22" }
        };

        public UrlParts GetUrlParts(string url)
        {
            return new UrlParts()
            {
                Protocol = GetProtocol(url),
                Subdomain = GetSubdomain(url),
                Domain = GetDomain(url),
                Port = GetPort(url),
                Path = GetPath(url)
            };
        }

        private string GetPath(string url)
        {
            var numberOfPathDelimiters = url.Count(c => c.Equals('/'));
            var path = numberOfPathDelimiters <= 2 ? string.Empty : GetPathOfUrlWhenPathExists(url);
            return path;
        }

        private string GetPathOfUrlWhenPathExists(string url)
        {
            var urlWithOutProtocolDelimilter = url.Replace("://", "");
            var lastIndexOfPathDelimiter = urlWithOutProtocolDelimilter.IndexOf("/", StringComparison.CurrentCultureIgnoreCase);
            var lenghtOfPathOnly = urlWithOutProtocolDelimilter.Length - lastIndexOfPathDelimiter;
            return urlWithOutProtocolDelimilter
                .Substring(lastIndexOfPathDelimiter, lenghtOfPathOnly)
                .Remove(0, 1);
        }

        private string GetPort(string url)
        {
            var indexOfPortDelimiter = url.LastIndexOf(":", StringComparison.CurrentCultureIgnoreCase);
            var numberOfIndexsAllowedBasedOnDefaultProtocols = 5;
            var port = indexOfPortDelimiter <= numberOfIndexsAllowedBasedOnDefaultProtocols
                ? _defaultPorts[GetProtocol(url)]
                : GetCustomPort(url);
            return port;
        }

        private string GetCustomPort(string url)
        {
            return GetUrlsplit(url).Select(s =>
            {
                int.TryParse(s, out int result);
                return result;
            }).Sum().ToString();
        }

        private string GetDomain(string url)
        {
            var urlsplit = GetUrlsplit(url);
            var domain = UrlContainsSubdomain(url) ? $"{urlsplit[2]}.{urlsplit[3]}" : $"{urlsplit[1]}.{urlsplit[2]}";
            return domain;
        }

        private bool UrlContainsSubdomain(string url)
        {
            var indexEndOfProtocol = url.IndexOf("://", StringComparison.CurrentCultureIgnoreCase);
            var numberOfProtocolDelimiter = 3;
            var urlWithOutProtocol = url.Remove(0, indexEndOfProtocol + numberOfProtocolDelimiter);
            var indexOfPortDelimiter = urlWithOutProtocol.IndexOf(":", StringComparison.CurrentCultureIgnoreCase);
            var indexOfFileDirectoryDelimiter = urlWithOutProtocol.IndexOf("/", StringComparison.CurrentCultureIgnoreCase);
            var endIndex = indexOfPortDelimiter >= 0 ? indexOfPortDelimiter : indexOfFileDirectoryDelimiter;
            endIndex = endIndex != -1 ? endIndex : urlWithOutProtocol.Length;
            var domainPossiblyWithSubdomain = urlWithOutProtocol.Substring(0, endIndex);
            var numberOfDotsInDomain = domainPossiblyWithSubdomain.Count(c => c == '.');
            return numberOfDotsInDomain == 2;
        }

        private string GetSubdomain(string url)
        {
            var urlsplit = GetUrlsplit(url);
            var subdomain = UrlContainsSubdomain(url) ? urlsplit[1] : string.Empty;
            return subdomain;
        }

        private string GetProtocol(string url)
        {
            var urlsplit = GetUrlsplit(url);
            var protocol = urlsplit[0];
            return protocol;
        }

        private string[] GetUrlsplit(string url)
        {
            var urlWithProtocol = url.Replace("://", ".");
            var urlsplit = urlWithProtocol.Split(new[] { ".", ":", "/" }, StringSplitOptions.RemoveEmptyEntries);
            return urlsplit;
        }
    }

    public class UrlParts
    {
        public string Protocol { get; set; }
        public string Subdomain { get; set; }
        public string Domain { get; set; }
        public string Port { get; internal set; }
        public string Path { get; set; }
    }
}
