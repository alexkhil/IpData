using FluentAssertions;
using IpData.Helpers;
using System;
using System.Globalization;
using Xunit;

namespace IpData.Tests.Helpers
{
    public class ApiUrlsTests
    {
        [Theory, AutoMoqData]
        public void Get_WhenCalledWithInvariantCulture_ReturnedUrl(string apiKey)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/?api-key={apiKey}";

            // Act
            var url = ApiUrls.Get(apiKey, CultureInfo.InvariantCulture);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Get_WhenCalledWithCulture_ReturnedUrl(string apiKey, CultureInfo culture)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/{culture}?api-key={apiKey}";

            // Act
            var url = ApiUrls.Get(apiKey, culture);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Get_WhenCalledWithIpAndInvariantCulture_ReturnedUrl(string apiKey, string ip)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/{ip}?api-key={apiKey}";

            // Act
            var url = ApiUrls.Get(apiKey, ip, CultureInfo.InvariantCulture);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Get_WhenCalledWithIpAndCulture_ReturnedUrl(string apiKey, string ip)
        {
            // Arrange
            var culture = CultureInfo.GetCultureInfo("zh-CN");
            var expectedUrl = $"https://api.ipdata.co/{ip}/{culture}?api-key={apiKey}";

            // Act
            var url = ApiUrls.Get(apiKey, ip, culture);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Get_WhenCalledWithValueTypeProp_ReturnedUrl(string apiKey, string ip)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/{ip}/count?api-key={apiKey}";

            // Act
            var url = ApiUrls.Get(apiKey, ip, x => x.Count);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Get_WhenCalledWithReferenceTypeProp_ReturnedUrl(string apiKey, string ip)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/{ip}/continent_name?api-key={apiKey}";

            // Act
            var url = ApiUrls.Get(apiKey, ip, x => x.ContinentName);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Get_WhenCalledWithInvalidProp_ReturnedUrl(string apiKey, string ip)
        {
            // Arrange
            Func<Uri> act = () => ApiUrls.Get(apiKey, ip, x => new { prop = "name" });

            // Act/Assert
            act.Should()
                .Throw<InvalidOperationException>()
                .Where(e => e.Message.Contains("Invalid expression"));
        }

        [Theory, AutoMoqData]
        public void Buld_WhenCalled_ReturnedUrl(string apiKey)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/bulk?api-key={apiKey}";

            // Act
            var url = ApiUrls.Bulk(apiKey);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Carrier_WhenCalled_ReturnedUrl(string apiKey, string ip)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/{ip}/carrier?api-key={apiKey}";

            // Act
            var url = ApiUrls.Carrier(apiKey, ip);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Asn_WhenCalled_ReturnedUrl(string apiKey, string ip)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/asn/{ip}?api-key={apiKey}";

            // Act
            var url = ApiUrls.Asn(apiKey, ip);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Timezone_WhenCalled_ReturnedUrl(string apiKey, string ip)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/{ip}/time_zone?api-key={apiKey}";

            // Act
            var url = ApiUrls.TimeZone(apiKey, ip);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Currency_WhenCalled_ReturnedUrl(string apiKey, string ip)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/{ip}/currency?api-key={apiKey}";

            // Act
            var url = ApiUrls.Currency(apiKey, ip);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }

        [Theory, AutoMoqData]
        public void Threat_WhenCalled_ReturnedUrl(string apiKey, string ip)
        {
            // Arrange
            var expectedUrl = $"https://api.ipdata.co/{ip}/threat?api-key={apiKey}";

            // Act
            var url = ApiUrls.Threat(apiKey, ip);

            // Assert
            url.AbsoluteUri.Should().Be(expectedUrl);
        }
    }
}
