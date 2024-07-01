using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Medium.RobberyOptimisation
{
    [TestClass]
    public class RobberyOptimisationTests
    {

        [TestMethod]
        [DataRow(new long[] { 5 }, 5)]
        [DataRow(new long[] { 1, 2, 3 }, 4)]
        [DataRow(new long[] { 1, 15, 10, 13, 16 }, 31)]
        [DataRow(new long[] { 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 50)]
        [DataRow(new long[] { 2, 5, 10, 2, 4, 8, 5, 2, 6, 7, 7, 6, 11, 12, 5, 9, 6, 10, 7, 9, 17, 63, 121, 12, 85, 95, 60, 100, 70, 91, 73, 26, 41, 28, 58, 19, 26, 17, 7, 9, 11, 23, 21, 42, 68, 65, 86, 101, 106, 1 }, 916)]
        [DataRow(new long[] { 4982344776663, 4925578712459, 276048193137, 6426523861909, 8356573974134, 3095979618228, 2624415575031, 2693605013601, 8317710116884, 6690539166454, 5076186282256, 1888419750516, 4239137764388, 9990688011400, 2199426040319, 9211878849601, 7758248669277, 22386343908, 694837123796, 4488988922248, 8977851521430, 3954483378225, 3320695129583, 105478574806, 9059391423799, 7609778880708, 6678220788963, 232866137717, 8063047783578, 1110365052303, 6615428677139, 3848170230495, 8216263982509, 5683625965890, 89167347384, 6843504041635, 5449923628136, 8445837250302, 4992797655695, 5377826978358, 1547804508573, 5972656430093, 4056450975935, 2229793906095, 6908940702002, 9232189899002, 6835019759847, 5354833176590, 9304183753524, 1225281550452, 5924162596011, 7125440661558, 7478903551232, 8833956235409, 2826107691855, 9241588690986, 3655986635420, 3963584091447, 2795615668153, 1344756766353, 5350902284712, 8274575011977, 1034067841086, 6667285804281, 2128692965563, 5488781726250, 8799482897915, 217680090456, 5497633732087, 5434050763962, 3426786173546, 67521712056, 1813573046435, 2323528608094, 1501564731907, 198461614324, 6411443381114, 4076671220937, 7128791272896, 426200218465, 8016191988500, 254934486195, 4543793647896, 386609368590, 2425758504588, 9041606569506, 5415537599373, 7097566870073, 3396294718545, 1933196385767, 9812781367885, 9755315665368, 2268411012001, 1876480899250, 6693805158002, 8149112391087, 107921777197, 2584253496650, 5223419248068, 8251735296974 }, 291429266834646)]
        [DataRow(new long[] { -2, -5, -10, -2, -4, -8, -5, -2, -6, -7 }, 0)]
        [DataRow(new long[] { -2, -5, -10, -2, 4, 8, -5, 2, -6, -7 }, 10)]
        public void GetMaximumAmount_WhenCalled_PerformsCorrectly(long[] values, long expected)
        {
            // Arrange
            RobberyOptimisation robberyOptimisation = new();

            // Act
            var actual = robberyOptimisation.GetMaximumAmount(values);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
