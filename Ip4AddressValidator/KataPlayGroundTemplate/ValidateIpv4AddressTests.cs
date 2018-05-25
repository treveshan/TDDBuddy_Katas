using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace KataPlayGroundTemplate
{
    [TestFixture]
    public class ValidateIpv4AddressTests
    {
        [TestFixture]
        public class ValidIpAddress
        {
            [Test]
            [TestCase("1.1.1.1")]
            [TestCase("192.168.1.1")]
            [TestCase("10.0.0.1")]
            [TestCase("127.0.0.1")]
            public void Validate_ShouldReturnTrue(string ipAddress)
            {
                // Arrange
                var validateIpv4Address = ValidateIpv4Address();

                // Act
                var result = validateIpv4Address.Validate(ipAddress);

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void Validate_GivenIpAddressWithFourOctet_ShouldReturnTrue()
            {
                // Arrange
                var validateIpv4Address = ValidateIpv4Address();
                var ipAddress = "2.2.2.2";
                // Act
                var result = validateIpv4Address.Validate(ipAddress);

                // Assert
                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class InvalidIpAddress
        {
            [Test]
            public void Validate_GivenIpAddressWithNoOctet_ShouldReturnFalse()
            {
                // Arrange
                var validateIpv4Address = ValidateIpv4Address();
                var ipAddress = string.Empty;
                // Act
                var result = validateIpv4Address.Validate(ipAddress);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            [TestCase("10")]
            [TestCase("10.10")]
            [TestCase("10.10.10")]
            [TestCase("10.10.10.10.10")]
            public void Validate_GivenIpAddressWithInvalidNumberOfOctets_ShouldReturnFalse(string ipAddress)
            {
                // Arrange
                var validateIpv4Address = ValidateIpv4Address();

                // Act
                var result = validateIpv4Address.Validate(ipAddress);

                // Assert
                Assert.That(result, Is.False);
            }


            [Test]
            [TestCase("1111.0.0.0")]
            [TestCase("111.11110.0.0")]
            [TestCase("1454511.1115410.111111110.54545455")]
            public void Validate_GivenIpAddressWithInvalidLenghtOfOctet_ShouldReturnFalse(string ipAddress)
            {
                // Arrange
                var validateIpv4Address = ValidateIpv4Address();

                // Act
                var result = validateIpv4Address.Validate(ipAddress);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            [TestCase("0.0.0.0")]
            [TestCase("111.111.0.0")]
            [TestCase("192.0.123.0")]
            [TestCase("192.1.1.0")]
            public void Validate_GivenIpAddressEndingWithZero_ShouldReturnFalse(string ipAddress)
            {
                // Arrange
                var validateIpv4Address = ValidateIpv4Address();

                // Act
                var result = validateIpv4Address.Validate(ipAddress);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            [TestCase("255.255.255.255")]
            [TestCase("111.111.0.255")]
            [TestCase("192.0.123.255")]
            [TestCase("192.1.1.255")]
            public void Validate_GivenIpAddressEndingWith255_ShouldReturnFalse(string ipAddress)
            {
                // Arrange
                var validateIpv4Address = ValidateIpv4Address();

                // Act
                var result = validateIpv4Address.Validate(ipAddress);

                // Assert
                Assert.That(result, Is.False);
            }
        }
        

        private static ValidateIpv4Address ValidateIpv4Address()
        {
            return new ValidateIpv4Address();
        }
    }
}
