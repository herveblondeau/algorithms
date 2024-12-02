using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.AdventOfCode._2024;

[TestClass]
public class Day1HistorianHysteriaTests
{
    [TestMethod]
    [DynamicData(nameof(CalculateDistance_SimpleCases_PerformsCorrectly_data), DynamicDataSourceType.Method)]
    public void CalculateDistance_SimpleCases_PerformsCorrectly(List<int> list1, List<int> list2, int expected)
    {
        // Arrange
        Day1HistorianHysteria day1HistorianHysteria = new();

        // Act
        var actual = day1HistorianHysteria.CalculateDistance(list1, list2);

        // Assert
        actual.Should().Be(expected);
    }

    public static IEnumerable<object[]> CalculateDistance_SimpleCases_PerformsCorrectly_data()
    {
        yield return new object[]
        {
            new List<int> {1},
            new List<int> {1},
            0
        };

        yield return new object[]
        {
            new List<int> {1},
            new List<int> {2},
            1
        };

        yield return new object[]
        {
            new List<int> {2},
            new List<int> {1},
            1
        };
    }

    [TestMethod]
    public void CalculateDistance_Sample_PerformsCorrectly()
    {
        // Arrange
        Day1HistorianHysteria day1HistorianHysteria = new();
        List<int> list1 = [3, 4, 2, 1, 3, 3];
        List<int> list2 = [4, 3, 5, 3, 9, 3];

        // Act
        var actual = day1HistorianHysteria.CalculateDistance(list1, list2);

        // Assert
        actual.Should().Be(11);
    }

    [TestMethod]
    public void CalculateDistance_Test_PerformsCorrectly()
    {
        // Arrange
        Day1HistorianHysteria day1HistorianHysteria = new();
        List<int> list1 = [68878, 24519, 73275, 87985, 80485, 98994, 28041, 50762, 23796, 71699, 43168, 12985, 38491, 30867, 89794, 59797, 62401, 90230, 40596, 52821, 61994, 62756, 91145, 57051, 36257, 36465, 98498, 49344, 13100, 82572, 77578, 99900, 75949, 50711, 52402, 69977, 23803, 57399, 81372, 98985, 76606, 86993, 54958, 23734, 25189, 11983, 53266, 31226, 54686, 60013, 29568, 97354, 91545, 15914, 64854, 30497, 39169, 13341, 89066, 89654, 59655, 89071, 91777, 28820, 68277, 24747, 19058, 50952, 77247, 79147, 89104, 26384, 58111, 61032, 45514, 37369, 66897, 42256, 53662, 18203, 14178, 16119, 85457, 74217, 72612, 30548, 21631, 55905, 15340, 44619, 67975, 22169, 15778, 63133, 42385, 51645, 30068, 44510, 50757, 31854, 54593, 16570, 21295, 70191, 64847, 30348, 92301, 66545, 32957, 49572, 10790, 85781, 32819, 22674, 44321, 39258, 25314, 98446, 96722, 96131, 60029, 22672, 57347, 55089, 93093, 46410, 46719, 48860, 75752, 32025, 58831, 93208, 93404, 91034, 74178, 99272, 24617, 31004, 49824, 50187, 64360, 40773, 93193, 24292, 66603, 94711, 81183, 38727, 47093, 94395, 39003, 40029, 90456, 75830, 33466, 16427, 49490, 52134, 67069, 35192, 82716, 74969, 16596, 30786, 69766, 88136, 29630, 98865, 83025, 38613, 34339, 20221, 60785, 42016, 50862, 91144, 82759, 34668, 80045, 17106, 47417, 62403, 58496, 98013, 82894, 93384, 95803, 76669, 14186, 40149, 50049, 62487, 32816, 84420, 54052, 91698, 62982, 34047, 32974, 36970, 14307, 26904, 36343, 43235, 76676, 55938, 34071, 72820, 17369, 46104, 88124, 31485, 50048, 11820, 81418, 45029, 10581, 49081, 52159, 81831, 88990, 43609, 32213, 40285, 99022, 53784, 88877, 50928, 41715, 88640, 57029, 47786, 85810, 11369, 70368, 94570, 39889, 13275, 68274, 77936, 15466, 44729, 32438, 41087, 60462, 65311, 32702, 82433, 93862, 33210, 94761, 42167, 35098, 27078, 54429, 27075, 97224, 56433, 30526, 40340, 69964, 58197, 86344, 28455, 87168, 73594, 43616, 36860, 62313, 63659, 19649, 63386, 70670, 25427, 95907, 90333, 88441, 52924, 54606, 53431, 72778, 32259, 22837, 41370, 50667, 23172, 87478, 18679, 25132, 35955, 19951, 92404, 43932, 89428, 68629, 18060, 96741, 46707, 89112, 55083, 41640, 17099, 70851, 23057, 19836, 25812, 93063, 45392, 21796, 97556, 57076, 58339, 58116, 91036, 60829, 22495, 66493, 15341, 50093, 20768, 23220, 51196, 23277, 37255, 42832, 60978, 81525, 75180, 69316, 29241, 11596, 34351, 43881, 18039, 35090, 37781, 90037, 58775, 11066, 35717, 73565, 26674, 91767, 20613, 98660, 19235, 52519, 40366, 33606, 67433, 51982, 21129, 26259, 41424, 15544, 85842, 44238, 50995, 50211, 88522, 85664, 83872, 90863, 12731, 35092, 89343, 43030, 14341, 67832, 65399, 40649, 99865, 84679, 37678, 40703, 36214, 38351, 41150, 82746, 34606, 32107, 35459, 26610, 18202, 34659, 89860, 25591, 11117, 90319, 36871, 94581, 56790, 13136, 12085, 75208, 80354, 61593, 21371, 44422, 37274, 13294, 12424, 57230, 95559, 18733, 95220, 15071, 70964, 55914, 57268, 61644, 14409, 19343, 79716, 57337, 35640, 65868, 21687, 90364, 81563, 99862, 50098, 56421, 87642, 80261, 80290, 69199, 52657, 82897, 55530, 77782, 60975, 99943, 14928, 32910, 73884, 81361, 13203, 72163, 82198, 46030, 33431, 30199, 58012, 60604, 66916, 59248, 52823, 67584, 35764, 38010, 53537, 40680, 77944, 65080, 15342, 66994, 46267, 80983, 78052, 54944, 37652, 60311, 51144, 31653, 55121, 36739, 20290, 86844, 90543, 36289, 42899, 19910, 16572, 22864, 68021, 49918, 93754, 51211, 98091, 51208, 12671, 61367, 58498, 26520, 16399, 26388, 20061, 42577, 46182, 45833, 75415, 45131, 78087, 37845, 73178, 38346, 36144, 95728, 24529, 13457, 80521, 26709, 96061, 39901, 59024, 70572, 26182, 54289, 77243, 45652, 61275, 76258, 87903, 36803, 34689, 78499, 97542, 99456, 31246, 67707, 53353, 72413, 77355, 11696, 38619, 58279, 32455, 13767, 53600, 52611, 69581, 84766, 25762, 75405, 94680, 19072, 64541, 47436, 55099, 62938, 85782, 49496, 26405, 33543, 98210, 26641, 78605, 48550, 91470, 76437, 26589, 37984, 47771, 69492, 30910, 72127, 20323, 68586, 85656, 50811, 91633, 97829, 64580, 87031, 16689, 93352, 91740, 86775, 63447, 69321, 21196, 40135, 94728, 68263, 49758, 58570, 70556, 28954, 23512, 79621, 23768, 68025, 94717, 32934, 25309, 31117, 28718, 11096, 82842, 10104, 15432, 58103, 36711, 62998, 56830, 74532, 10346, 43025, 31908, 38840, 42859, 16034, 56548, 36514, 93380, 89108, 14520, 61195, 59069, 75276, 94795, 16658, 23381, 80772, 22003, 78628, 53837, 53845, 87259, 96036, 43607, 90261, 97376, 11241, 13946, 48838, 26427, 24683, 61135, 39381, 66763, 50727, 26719, 91561, 27810, 25003, 87375, 47591, 15769, 62428, 58030, 42184, 16058, 49021, 60036, 79735, 28417, 75666, 45303, 99666, 83328, 34405, 40795, 94482, 73638, 11760, 18055, 42382, 74101, 53388, 80963, 35307, 24016, 76700, 11790, 37543, 23488, 79409, 84795, 72611, 24699, 43748, 89525, 67690, 77431, 18256, 47688, 27275, 28105, 99231, 10732, 96670, 67501, 24786, 72693, 11436, 44962, 11976, 23830, 20155, 49298, 15879, 46430, 58886, 38384, 54723, 40400, 11657, 45050, 85338, 83322, 47722, 16468, 95873, 41360, 66342, 87812, 28383, 91602, 40405, 77890, 98616, 22404, 54032, 52902, 91840, 63905, 10098, 11009, 88737, 64422, 37474, 41788, 76027, 17826, 79264, 98770, 13862, 38691, 21357, 32360, 18251, 38720, 36065, 35917, 60979, 91586, 28849, 40735, 26437, 86360, 35949, 83277, 38624, 52011, 39123, 27513, 62673, 94379, 23909, 77737, 70404, 62370, 84827, 53387, 87556, 80571, 26409, 13990, 11278, 16299, 63994, 86493, 29416, 17711, 80358, 56072, 93254, 91931, 53072, 24215, 90482, 21665, 64002, 84470, 81717, 41573, 46883, 19788, 41097, 80709, 37670, 49520, 19523, 83480, 67124, 90934, 87043, 50073, 81378, 51195, 87524, 54555, 49730, 91852, 14863, 74431, 39883, 99545, 49954, 50720, 82282, 27672, 48615, 16323, 34687, 84144, 43893, 58000, 63630, 42225, 10697, 84790, 84555, 11332, 55152, 17760, 74448, 72412, 81795, 28000, 58978, 97634, 12089, 21668, 98314, 27619, 34387, 64406, 54811, 28351, 79006, 49237, 30856, 59999, 76251, 14006, 88588, 97866, 11813, 91016, 43424, 83490, 78507, 91517, 55040, 21483, 47039, 97168, 96466, 66156, 50285, 14057, 73017, 33025, 97174, 65673, 19216, 44883, 30254, 31552, 76764, 60507, 18078, 46186, 90898, 23982, 37504, 72585, 17791, 79779, 25517, 54064, 47343, 11730, 14957, 30186, 66079, 82720, 59760, 23159, 21390, 12330, 38607, 96534, 65278, 48760, 34518, 79376, 40307, 59634, 16764, 20484, 40175, 12457, 56023, 63916, 46289, 91143, 65424, 39578, 79985, 72984, 41823, 98393, 48951, 51888, 85621, 49048, 48878, 91067, 67152, 80589, 80824, 65118, 66648, 17766, 83672, 81351, 72780, 87114, 74871, 62623, 68716, 72795, 97700, 80913, 21100, 49723, 30881, 42287, 90849, 13053, 90689, 91029, 61953, 67212, 70587, 50801, 44701, 67526, 64537, 10820, 94953, 93517, 84240, 72049, 17021, 41393, 88520, 63317, 28723, 64942, 10994, 57068, 15289, 20900, 32744, 18435, 95710, 14710, 31598, 63543, 29870, 20129, 21868, 76460, 65538, 84172, 77952, 26417, 93014, 66327, 40867, 65286, 93712, 73589, 91733, 55558, 11506, 59048, 62575, 96799, 46068, 32722, 42557, 83134, 52665, 38085, 33365, 74033, 49743, 47311, 41588, 78063, 83201, 57980, 58451, 81627];
        List<int> list2 = [98732, 87903, 70114, 89419, 75440, 55979, 41805, 92905, 72412, 84915, 71645, 96078, 34431, 76208, 10790, 86225, 50098, 45208, 36238, 75949, 85771, 70340, 33842, 45050, 80983, 84670, 23292, 50098, 22817, 57598, 36555, 91029, 26486, 74711, 27513, 71045, 41588, 16399, 45126, 10547, 99481, 78240, 27513, 61444, 10790, 91029, 91029, 16399, 86915, 40760, 52436, 44827, 40986, 60707, 49298, 66916, 92811, 98568, 41215, 33815, 66645, 48550, 41832, 23803, 10790, 20641, 68263, 65659, 71079, 28383, 79596, 27513, 79657, 72412, 49298, 80983, 96745, 18346, 67789, 50098, 24879, 50862, 55460, 62672, 50061, 32091, 49298, 19836, 92089, 28383, 95646, 56053, 32810, 98314, 35192, 87903, 80881, 83025, 59248, 16399, 27981, 11600, 99780, 38799, 16732, 30596, 49298, 23803, 27513, 10507, 65414, 24738, 50098, 23803, 40307, 19836, 27018, 83025, 15026, 51435, 46857, 24485, 40735, 65268, 57076, 40686, 49999, 80891, 40285, 76676, 14816, 75949, 87903, 54811, 40675, 84920, 59248, 22425, 79823, 76234, 55010, 10935, 28383, 27513, 96899, 49904, 59248, 50143, 34542, 41907, 89663, 57072, 84416, 87903, 27513, 59248, 33354, 40307, 80983, 57341, 11017, 49298, 30045, 50769, 39818, 94929, 70754, 52818, 52968, 75675, 87903, 11583, 21075, 32352, 54811, 10790, 92299, 35814, 80983, 87903, 28383, 75949, 77896, 75949, 34330, 44962, 10790, 66543, 80983, 58549, 40735, 55256, 59248, 67838, 83025, 73884, 26639, 65346, 19836, 14966, 18019, 87903, 72547, 89108, 72412, 66916, 16143, 64337, 17215, 45050, 73288, 52329, 87903, 51419, 69376, 97736, 25449, 33618, 99078, 98314, 32303, 44962, 40285, 83782, 50098, 22929, 40307, 58596, 92182, 20046, 69964, 36174, 15842, 90510, 27513, 64489, 80581, 16427, 27513, 51774, 29702, 80983, 16399, 23803, 49298, 76326, 40735, 97292, 90212, 81930, 90283, 74463, 48550, 99873, 12606, 89108, 73884, 68263, 59248, 10790, 48550, 72412, 18262, 87594, 57559, 65764, 54811, 55905, 46800, 87903, 40735, 45583, 96410, 84151, 50098, 92116, 40735, 40735, 93929, 35192, 94800, 44962, 15734, 20407, 91029, 20736, 78442, 67415, 27513, 72412, 42485, 73884, 75949, 47755, 23255, 75949, 67071, 89108, 92197, 71071, 66916, 58116, 16399, 92148, 92356, 72833, 23164, 59203, 69964, 35192, 97029, 50098, 62171, 98314, 59813, 46432, 29832, 17977, 59248, 10238, 40987, 62761, 80983, 28383, 93721, 28336, 16486, 66916, 49298, 48253, 50862, 31482, 52947, 15790, 47718, 66916, 44975, 49298, 92303, 97563, 49309, 96015, 35192, 29701, 26456, 73884, 61051, 14356, 59248, 78913, 98675, 45050, 59939, 74011, 18046, 93362, 54811, 77228, 45766, 55008, 10790, 49541, 66681, 80983, 44962, 27513, 59369, 14679, 54811, 97833, 53538, 39569, 16399, 91006, 80889, 88977, 87638, 30413, 40735, 89108, 18123, 50816, 23803, 49298, 23803, 35192, 72412, 92839, 83025, 40735, 72076, 46209, 81739, 62323, 37298, 40735, 39732, 71180, 19479, 27513, 41590, 22554, 40809, 81507, 43631, 79915, 92369, 57296, 83712, 87903, 20006, 58116, 90069, 73884, 79683, 48701, 66918, 49298, 90368, 96307, 35192, 23985, 33574, 50862, 57845, 53468, 73884, 73884, 13916, 23966, 54811, 11030, 66089, 40735, 50078, 52473, 58116, 16427, 80438, 13938, 38491, 52909, 40285, 61365, 88325, 73884, 10790, 68263, 38374, 58969, 35192, 27513, 90231, 85142, 80983, 65310, 49661, 41636, 95143, 36273, 49284, 65872, 89108, 69333, 48550, 87873, 66142, 69352, 80544, 40885, 61112, 95984, 73884, 40307, 91559, 38491, 73786, 91029, 96235, 95113, 26252, 40285, 89030, 75949, 61255, 35061, 40307, 45050, 59248, 23803, 22608, 35192, 27513, 72412, 59937, 40307, 10790, 48550, 35192, 74785, 62690, 90830, 87903, 58362, 75949, 36414, 73484, 48550, 44962, 41357, 63563, 33760, 58116, 75949, 72708, 49298, 69964, 16399, 23803, 97810, 66916, 76845, 81639, 91427, 37641, 66916, 27513, 46733, 10790, 12534, 86767, 58116, 44962, 84153, 27675, 98620, 83025, 25303, 48379, 77486, 40285, 22822, 68211, 18321, 53744, 17305, 70987, 23803, 91029, 59527, 48391, 68552, 42659, 75949, 69964, 17034, 48550, 74549, 54811, 49347, 29122, 13067, 94888, 30618, 50862, 35192, 21275, 27513, 66916, 40735, 85095, 96099, 24597, 83025, 78089, 75949, 40307, 80983, 87903, 75949, 26912, 89108, 71387, 39913, 38491, 46226, 91819, 37008, 80983, 17899, 44147, 18566, 81227, 10790, 76676, 73884, 40285, 78375, 31492, 30023, 96892, 83025, 68263, 32521, 95622, 85880, 49638, 55668, 65113, 91029, 89108, 53666, 43105, 19836, 80983, 80790, 73884, 34325, 85258, 55484, 28264, 75949, 55158, 52565, 46873, 56491, 35216, 88573, 38491, 72412, 47195, 71602, 16399, 73008, 57060, 23803, 80469, 40479, 80117, 78617, 95360, 40285, 59248, 18264, 66916, 16399, 64973, 87903, 34050, 45905, 58844, 47904, 27513, 27513, 57076, 76842, 72412, 73884, 73884, 89766, 22330, 61832, 75326, 61479, 69002, 54811, 40735, 38262, 73517, 48550, 72142, 49298, 48550, 98314, 26597, 66916, 65012, 69964, 54811, 75949, 47666, 40307, 82188, 16141, 95724, 58116, 11225, 16427, 57220, 75949, 29692, 40758, 38491, 19053, 32623, 73884, 67754, 45721, 16399, 45050, 35986, 66916, 83411, 24658, 81506, 47035, 36775, 87399, 39066, 15602, 89236, 81548, 49298, 35192, 44962, 16399, 98314, 12686, 54811, 35192, 23803, 88518, 95536, 91339, 15249, 50042, 64640, 36874, 57804, 27513, 78686, 52496, 48550, 31160, 75949, 16399, 18939, 89952, 67949, 58746, 19975, 45050, 19228, 50098, 10790, 49393, 39337, 89108, 15222, 83025, 90571, 93244, 70858, 84696, 44218, 35250, 89108, 51193, 91029, 83025, 34702, 89667, 65610, 54811, 78479, 28383, 80983, 39436, 73884, 16399, 98128, 98633, 97373, 40735, 80983, 27470, 67708, 22587, 16167, 93408, 23282, 38138, 69964, 40544, 42044, 22439, 88126, 21464, 65017, 10790, 61975, 80983, 10790, 49298, 84396, 72412, 93792, 25266, 80983, 50098, 39659, 54616, 66849, 34776, 88195, 23803, 30556, 25955, 16399, 17912, 93219, 59248, 50098, 49298, 50098, 67228, 91029, 35192, 78826, 99596, 65194, 23577, 75949, 91029, 74439, 11140, 59248, 92514, 40285, 70596, 36254, 92362, 46580, 10460, 46374, 48734, 98298, 91029, 33976, 91029, 10790, 83025, 32540, 72412, 89604, 91029, 21407, 83837, 75811, 38491, 28383, 85652, 91029, 19440, 79572, 15856, 15804, 59248, 34215, 87903, 40285, 29668, 16427, 41588, 39147, 54811, 23803, 40735, 80710, 89108, 84089, 66916, 57516, 54811, 59248, 16399, 23803, 14989, 89338, 66916, 44962, 77329, 50098, 90747, 53663, 97111, 58227, 91626, 47541, 48439, 36080, 68532, 51086, 10950, 72383, 70481, 34025, 58517, 70209, 44935, 70887, 52243, 22203, 35192, 76917, 10103, 40735, 89069, 44767, 27513, 87903, 73884, 73125, 59248, 52481, 59248, 83025, 13909, 35572, 42040, 87903, 75949, 29739, 73816, 49219, 72092, 40307, 80983, 37233, 10790, 80895, 28982, 50862, 14799, 50862, 19117, 43248, 50164, 31660, 40285, 68049, 72412, 98405, 23823, 57422, 72412, 45050, 80983, 10790, 72559, 57245, 28383, 74185, 27513, 34190, 93681, 53584, 35192, 41588, 72823, 35192, 69585, 87903, 10790, 91029, 16427, 49298, 73884, 72412, 51085, 35689, 78889, 89108, 13137, 10790, 76246, 91171, 30084, 49842, 37212, 83025, 71853, 73247, 92730, 93958, 12454, 26234, 54811, 73128, 69964, 22988, 87903, 38491, 92414, 38093, 48550, 80983, 35192, 71130, 56209];

        // Act
        var actual = day1HistorianHysteria.CalculateDistance(list1, list2);

        // Assert
        actual.Should().Be(1834060);
    }
}
