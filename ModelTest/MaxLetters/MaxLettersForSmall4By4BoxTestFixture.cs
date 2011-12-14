using NUnit.Framework;

namespace Model.Test.MaxLetters {
    [TestFixture]
    public class MaxLettersForSmall4By4BoxTestFixture : MaxLettersForBoxTestFixtureBase {
        protected override WordSearchBox TestSearchBox {
            get { return new WordSearchBox("abcdabcdabcdabcd", 4); }
        }

        [Test]
        [TestCase(0, 1)][TestCase(1, 2)][TestCase(2, 3)][TestCase(3, 4)]
        [TestCase(4, 1)][TestCase(5, 2)][TestCase(6, 3)][TestCase(7, 4)]
        [TestCase(8, 1)][TestCase(9, 2)][TestCase(10, 3)][TestCase(11, 4)]
        [TestCase(12, 1)][TestCase(13, 2)][TestCase(14, 3)][TestCase(15, 4)]
        public override void TestLeftWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestLeftWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [Test]
        [TestCase(0, 4)]
        [TestCase(1, 3)]
        [TestCase(2, 2)]
        [TestCase(3, 1)]
        [TestCase(4, 4)]
        [TestCase(5, 3)]
        [TestCase(6, 2)]
        [TestCase(7, 1)]
        [TestCase(8, 4)]
        [TestCase(9, 3)]
        [TestCase(10, 2)]
        [TestCase(11, 1)]
        [TestCase(12, 4)]
        [TestCase(13, 3)]
        [TestCase(14, 2)]
        [TestCase(15, 1)]
        public override void TestRightWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestRightWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [Test]
        [TestCase(0, 4)]
        [TestCase(1, 4)]
        [TestCase(2, 4)]
        [TestCase(3, 4)]
        [TestCase(4, 3)]
        [TestCase(5, 3)]
        [TestCase(6, 3)]
        [TestCase(7, 3)]
        [TestCase(8, 2)]
        [TestCase(9, 2)]
        [TestCase(10, 2)]
        [TestCase(11, 2)]
        [TestCase(12, 1)]
        [TestCase(13, 1)]
        [TestCase(14, 1)]
        [TestCase(15, 1)]
        public override void TestDownWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestDownWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(6, 2)]
        [TestCase(7, 2)]
        [TestCase(8, 3)]
        [TestCase(9, 3)]
        [TestCase(10, 3)]
        [TestCase(11, 3)]
        [TestCase(12, 4)]
        [TestCase(13, 4)]
        [TestCase(14, 4)]
        [TestCase(15, 4)]
        public override void TestUpWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestUpWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [Test]
        [TestCase(0, 4)]
        [TestCase(1, 3)]
        [TestCase(2, 2)]
        [TestCase(3, 1)]
        [TestCase(4, 3)]
        [TestCase(5, 3)]
        [TestCase(6, 2)]
        [TestCase(7, 1)]
        [TestCase(8, 2)]
        [TestCase(9, 2)]
        [TestCase(10, 2)]
        [TestCase(11, 1)]
        [TestCase(12, 1)]
        [TestCase(13, 1)]
        [TestCase(14, 1)]
        [TestCase(15, 1)]
        public override void TestDiagonallyRightDownWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestDiagonallyRightDownWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        [TestCase(4, 1)]
        [TestCase(5, 2)]
        [TestCase(6, 3)]
        [TestCase(7, 3)]
        [TestCase(8, 1)]
        [TestCase(9, 2)]
        [TestCase(10, 2)]
        [TestCase(11, 2)]
        [TestCase(12, 1)]
        [TestCase(13, 1)]
        [TestCase(14, 1)]
        [TestCase(15, 1)]
        public override void TestDiagonallyLeftDownWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestDiagonallyLeftDownWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(6, 2)]
        [TestCase(7, 1)]
        [TestCase(8, 3)]
        [TestCase(9, 3)]
        [TestCase(10, 2)]
        [TestCase(11, 1)]
        [TestCase(12, 4)]
        [TestCase(13, 3)]
        [TestCase(14, 2)]
        [TestCase(15, 1)]
        public override void TestDiagonallyRightUpWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestDiagonallyRightUpWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 2)]
        [TestCase(6, 2)]
        [TestCase(7, 2)]
        [TestCase(8, 1)]
        [TestCase(9, 2)]
        [TestCase(10, 3)]
        [TestCase(11, 3)]
        [TestCase(12, 1)]
        [TestCase(13, 2)]
        [TestCase(14, 3)]
        [TestCase(15, 4)]
        public override void TestDiagonallyLeftUpWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestDiagonallyLeftUpWordMaxLettersAreCorrect(startLetter, maxLetters);
        }
    }
}