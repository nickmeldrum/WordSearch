using NUnit.Framework;

namespace Model.Test.MaxLetters {
    [TestFixture]
    public class MaxLettersForSmall6By2BoxTestFixture : MaxLettersForBoxTestFixtureBase {
        protected override WordSearchBox TestSearchBox { get { return new WordSearchBox("abcdef", 3); } }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 1)]
        [TestCase(4, 2)]
        [TestCase(5, 3)]
        public override void TestLeftWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestLeftWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [TestCase(0, 3)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(3, 3)]
        [TestCase(4, 2)]
        [TestCase(5, 1)]
        public override void TestRightWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestRightWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [TestCase(0, 2)]
        [TestCase(1, 2)]
        [TestCase(2, 2)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 1)]
        public override void TestDownWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestDownWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        public override void TestUpWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestUpWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [TestCase(0, 2)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 1)]
        public override void TestDiagonallyRightDownWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestDiagonallyRightDownWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 2)]
        [TestCase(3, 1)]
        [TestCase(4, 1)]
        [TestCase(5, 1)]
        public override void TestDiagonallyLeftDownWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestDiagonallyLeftDownWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 2)]
        [TestCase(5, 1)]
        public override void TestDiagonallyRightUpWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestDiagonallyRightUpWordMaxLettersAreCorrect(startLetter, maxLetters);
        }

        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        public override void TestDiagonallyLeftUpWordMaxLettersAreCorrect(int startLetter, int maxLetters) {
            base.TestDiagonallyLeftUpWordMaxLettersAreCorrect(startLetter, maxLetters);
        }
    }
}
