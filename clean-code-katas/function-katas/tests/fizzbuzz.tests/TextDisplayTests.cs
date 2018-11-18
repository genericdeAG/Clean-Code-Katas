using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace fizzbuzz.tests
{
    public class TextDisplayTests
    {
        private readonly TextDisplay _target;
        public TextDisplayTests()
        {
            _target = new TextDisplay();
        }

        [Fact]
        public void DisplayTexts_GivenTexts_ShouldDisplayTexts()
        {
            var texts = new List<string>
            {
                "1",
                "2",
                "Fizz",
                "4",
                "Buzz",
                "Fizz",
                "7",
                "8",
                "Fizz",
                "Buzz",
                "11",
                "Fizz",
                "13",
                "14",
                "FizzBuzz"
            };

            var expected = "1,2,Fizz,4,Buzz,Fizz,7,8,Fizz,Buzz,11,Fizz,13,14,FizzBuzz";

            var actual = string.Empty;
            void DisplayAction(string s) => actual = s;
            _target.DisplayTexts(texts, DisplayAction);

            expected.Should().BeEquivalentTo(actual);
        }
    }
}