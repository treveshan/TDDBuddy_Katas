using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace KataPlayGroundTemplate
{
    [TestFixture]
    public class UrlHelperTest
    {
        public class GetUrlParts
        {
            [Test]
            public void GivenValidUrl_ShouldReturnUrlParts()
            {
                //Arrange
                var urlHelper = UrlHelper();
                var url = "http://www.tddbuddy.com";
                //Arrange
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                Assert.That(urlParts, Is.TypeOf<UrlParts>());
            }

            [Test]
            [TestCase("http://www.tddbuddy.com", "http")]
            [TestCase("https://www.buddy.com", "https")]
            [TestCase("ftp://foo.com:9000/files", "ftp")]
            [TestCase("ftps://foo.com:9000/files", "ftps")]
            public void GivenUrl_ShouldReturnProtocol(string url, string protocol)
            {
                //Arrange
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = protocol;
                Assert.That(urlParts.Protocol, Is.EqualTo(expected));
            }


            [Test]
            [TestCase("http://www.tddbuddy.com", "www")]
            [TestCase("https://www.tddbuddy.com", "www")]
            [TestCase("ftp://www.foo.com:9900/files", "www")]
            [TestCase("ftps://www.foo.com:8500/files", "www")]
            public void GivenUrlWithSubdomain_ShouldReturnSubdomain(string url, string subdomain)
            {
                //Arrange
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = subdomain;
                Assert.That(urlParts.Subdomain, Is.EqualTo(expected));
            }

            [Test]
            [TestCase("http://tddbuddy.com")]
            [TestCase("https://tddbuddy.com")]
            [TestCase("ftp://foo.com:9900/files")]
            [TestCase("ftps://foo.com/files")]
            public void GivenUrlWithNoSubdomain_ShouldReturnEmptyString(string url)
            {
                //Arrange
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = string.Empty;
                Assert.That(urlParts.Subdomain, Is.EqualTo(expected));
            }

            [Test]
            [TestCase("http://katas.tddbuddy.com", "katas")]
            [TestCase("https://kata.tddbuddy.com", "kata")]
            [TestCase("ftp://foo.zoo.com:9900/files", "foo")]
            [TestCase("ftps://woo.too.com:8500/files", "woo")]
            public void GivenUrlNotUsingWWWsubdomain_ShouldReturnSubdomain(string url, string subdomain)
            {
                //Arrange
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = subdomain;
                Assert.That(urlParts.Subdomain, Is.EqualTo(expected));
            }

            [Test]
            [TestCase("http://tddbuddy.com", "tddbuddy.com")]
            [TestCase("https://buddy.io", "buddy.io")]
            [TestCase("ftp://foo.net:9900/files", "foo.net")]
            [TestCase("ftps://qoo.biz:8500/files", "qoo.biz")]
            public void GivenUrlWithNoSubdomain_ShouldReturnDomain(string url, string domain)
            {
                //Arrange
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = domain;
                Assert.That(urlParts.Domain, Is.EqualTo(expected));
            }

            [Test]
            [TestCase("http://www.tddbuddy.com", "tddbuddy.com")]
            [TestCase("https://www.buddy.io", "buddy.io")]
            [TestCase("ftp://www.foo.net:9900/files", "foo.net")]
            [TestCase("ftps://www.qoo.biz:8500/files", "qoo.biz")]
            public void GivenUrl_ShouldWithSubdomainReturnDomain(string url, string domain)
            {
                //Arrange
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = domain;
                Assert.That(urlParts.Domain, Is.EqualTo(expected));
            }

            [Test]
            [TestCase("http://www.tddbuddy.com", "80")]
            [TestCase("https://www.buddy.io", "443")]
            [TestCase("ftp://www.foo.net/files", "21")]
            [TestCase("ftps://www.qoo.biz/files", "22")]
            public void GivenUrlWithNoPortSpecfied_ShouldReturnDefaultPort(string url, string port)
            {
                //Arrange
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = port;
                Assert.That(urlParts.Port, Is.EqualTo(expected));
            }

            [Test]
            [TestCase("http://www.tddbuddy.com:8080/test.html", "8080")]
            [TestCase("https://www.buddy.io:444", "444")]
            [TestCase("ftp://www.foo.net:9000", "9000")]
            [TestCase("ftps://www.qoo.biz:9001/files", "9001")]
            public void GivenUrlWithPortSpecfied_ShouldReturnDefaultPort(string url, string port)
            {
                //Arrange
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = port;
                Assert.That(urlParts.Port, Is.EqualTo(expected));
            }

            [Test]
            [TestCase("http://www.tddbuddy.com")]
            [TestCase("https://www.buddy.io")]
            [TestCase("ftp://www.foo.net")]
            [TestCase("ftps://www.qoo.biz")]
            public void GivenUrlWithNoPath_ShouldReturnEmptyString(string url)
            {
                //Arrange
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = string.Empty;
                Assert.That(urlParts.Path, Is.EqualTo(expected));
            }

            [Test]
            [TestCase("http://www.tddbuddy.com/foobar.html", "foobar.html")]
            [TestCase("https://www.buddy.io/foo/bar.html", "foo/bar.html")]
            [TestCase("ftp://www.foo.net/download/install.exe", "download/install.exe")]
            [TestCase("ftps://www.qoo.biz/files", "files")]
            public void GivenUrlWithPath_ShouldReturnEmptyString(string url, string path)
            {
                //Arrange
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = path;
                Assert.That(urlParts.Path, Is.EqualTo(expected));
            }

            public void GivenHttpUrlFromExplain_ShouldReturnCorrectUrlParts()
            {
                //Arrange
                var url= "http://www.tddbuddy.com";
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = new UrlParts()
                {
                    Protocol = "http",
                    Subdomain = "www",
                    Domain = "tddbuddy.com",
                    Path = string.Empty,
                    Port = "80"
                };
                Assert.That(urlParts, Is.EqualTo(expected));
            }

            public void GivenHttpUrlWithPathFromExplain_ShouldReturnCorrectUrlParts()
            {
                //Arrange
                var url= "http://foo.bar.com/foobar.html";
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = new UrlParts()
                {
                    Protocol = "http",
                    Subdomain = "foo",
                    Domain = "bar.com",
                    Path = "foobar.html",
                    Port = "80"
                };
                Assert.That(urlParts, Is.EqualTo(expected));
            }

            public void GivenHttpsUrlWithPathFromExplain_ShouldReturnCorrectUrlParts()
            {
                //Arrange
                var url= "https://www.foobar.com:8080/download/install.exe";
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = new UrlParts()
                {
                    Protocol = "https",
                    Subdomain = "www",
                    Domain = "foobar.com",
                    Path = "download/install.exe",
                    Port = "8080"
                };
                Assert.That(urlParts, Is.EqualTo(expected));
            }
            public void GivenFTPUrlWithPathFromExplain_ShouldReturnCorrectUrlParts()
            {
                //Arrange
                var url= "ftp://foo.com:9000/files";
                var urlHelper = UrlHelper();
                //Act
                var urlParts = urlHelper.GetUrlParts(url);
                //Assert
                var expected = new UrlParts()
                {
                    Protocol = "ftp",
                    Subdomain = string.Empty,
                    Domain = "foo.com",
                    Path = "files",
                    Port = "9000"
                };
                Assert.That(urlParts, Is.EqualTo(expected));
            }
        }
        private static UrlHelper UrlHelper()
        {
            return new UrlHelper();
        }
    }
}
