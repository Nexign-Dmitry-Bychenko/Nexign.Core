using System;
using System.Collections.Generic;

using Xunit;

using Nexign.Core;

namespace Nexign.Core.Tests {

  public class SemanticVersionTests {
    #region Standard Tests

    [Fact(DisplayName = "Simple Formatting")]
    public void SimpleFormatting() {
      string expected = "1.2.3";
      string actual = new SemanticVersion(1, 2, 3).ToString();

      Assert.Equal(actual, expected);
    }

    [Fact(DisplayName = "Complex Formatting")]
    public void ComplexFormatting() {
      string expected = "12.24.345-pre (1456)+x-ab12";
      string actual = new SemanticVersion(12, 24, 345, "pre (1456)", "x-ab12").ToString();

      Assert.Equal(actual, expected);
    }

    [Fact(DisplayName = "Simple Comparison")]
    public void SimpleComparisons() {
      Assert.True(new SemanticVersion(1, 2, 3) == new SemanticVersion(1, 2, 3));
      Assert.True(new SemanticVersion(1, 2, 3) >= new SemanticVersion(1, 2, 3));
      Assert.True(new SemanticVersion(1, 2, 3) <= new SemanticVersion(1, 2, 3));

      Assert.True(new SemanticVersion(1, 2, 4) != new SemanticVersion(1, 2, 5));
      Assert.True(new SemanticVersion(1, 2, 5) != new SemanticVersion(1, 2, 4));
      Assert.True(new SemanticVersion(1, 2, 4) > new SemanticVersion(1, 2, 3));
      Assert.True(new SemanticVersion(1, 2, 4) < new SemanticVersion(1, 2, 5));
    }

    [Fact(DisplayName = "Complex Comparison")]
    public void ComplexComparisons() {
      Assert.True(new SemanticVersion(1, 2, 4, "rc2") > new SemanticVersion(1, 2, 4, "rc10"));
      Assert.True(new SemanticVersion(1, 2, 4, "rc2", "aa") > new SemanticVersion(1, 2, 4, "rc10", "zz"));
      Assert.True(new SemanticVersion(1, 2, 4, "rc2", "abc") < new SemanticVersion(1, 2, 4, "rc2", "def"));
    }

    [Fact(DisplayName = "Simple Partitions")]
    public void SimpleParts() {
      SemanticVersion version = new SemanticVersion(11, 25, 535, "pre-493", "Build Me Up");

      Assert.Equal(11, version.Major);
      Assert.Equal(25, version.Minor);
      Assert.Equal(535, version.Patch);
      Assert.Equal("pre-493", version.PreRelease[0]);
      Assert.Equal("Build Me Up", version.BuildMetaData[0]);
    }

    [Fact(DisplayName = "Hash")]
    public void SimpleDictionaries() {
      Dictionary<SemanticVersion, int> dict = new Dictionary<SemanticVersion, int>() {
        { new SemanticVersion(4, 5, 6, "rc", "abc"), 123}
      };

      Assert.True(dict.ContainsKey(new SemanticVersion(4, 5, 6, "rc", "abc")));
    }

    #endregion Standard Tests
  }
}
