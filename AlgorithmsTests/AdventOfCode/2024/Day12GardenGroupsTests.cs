using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.AdventOfCode._2024;

[TestClass]
public class Day12GardenGroupsTests
{

    #region Part 1

    [TestMethod]
    public void CalculateTotalPrice_SampleMap_PerformsCorrectly()
    {
        // Arrange
        Day12GardenGroups day12GardenGroup = new();
        var map = _getSampleMap();

        // Act
        var actual = day12GardenGroup.CalculateTotalPrice(map);

        // Assert
        actual.Should().Be(1930);
    }

    [TestMethod]
    public void CalculateTotalPrice_TestMap_PerformsCorrectly()
    {
        // Arrange
        Day12GardenGroups day12GardenGroup = new();
        var map = _getTestMap();

        // Act
        var actual = day12GardenGroup.CalculateTotalPrice(map);

        // Assert
        actual.Should().Be(1431440);
    }

    #endregion

    #region Part 2

    [TestMethod]
    public void CalculateBulkDiscountPrice_SampleMap_PerformsCorrectly()
    {
        // Arrange
        Day12GardenGroups day12GardenGroup = new();
        var map = _getSampleMap();

        // Act
        var actual = day12GardenGroup.CalculateBulkDiscountPrice(map);

        // Assert
        actual.Should().Be(1206);
    }

    [TestMethod]
    public void CalculateBulkDiscountPrice_TestMap_PerformsCorrectly()
    {
        // Arrange
        Day12GardenGroups day12GardenGroup = new();
        var map = _getTestMap();

        // Act
        var actual = day12GardenGroup.CalculateBulkDiscountPrice(map);

        // Assert
        actual.Should().Be(869070);
    }

    #endregion

    private string[] _getSampleMap()
    {
        return
        [
            "RRRRIICCFF",
            "RRRRIICCCF",
            "VVRRRCCFFF",
            "VVRCCCJFFF",
            "VVVVCJJCFE",
            "VVIVCCJJEE",
            "VVIIICJJEE",
            "MIIIIIJJEE",
            "MIIISIJEEE",
            "MMMISSJEEE",
        ];
    }

    private string[] _getTestMap()
    {
        return
        [
            "AAAAARRRRRRRRRRROOOOOOOOOOOOWWWWWWWWWWWWWMMMMXXQQQQQQQWWWXXXXXXXXQQQQQQQQQQQQQQQQQQQDDDDDDBBBBBBBBBBBBBBBBBRRRRRRRRRRREEEEEEEEEEEEEJJJJJJJJJ",
            "AAAAARRRRRRRROOROOOOOOOOOOWWWWWWWWWWWWWWWWWMMMMQQQQQQQQWXXXXXXXXXQQQQXQQQQQQQQQQQQQQDDDDDDBBBBBBBBBBBBBBBBBRRRRRRRREEEEEEEEEEEEEZEJJJJJJJJJJ",
            "OAAAARRRRRRRRROOOOOOOOOOOWWWWWWWWWWWWWWWWWWMMMMQQQQJQQQWXXXXXXXXXXXXXXXQQQQQQQQQQQQQDDDDDBBBBBBBBBBBBBBBBBBRZRRRRRRRREEEEEEEEEEEJJJJJJJJJJJJ",
            "AAAAARRRRRRRRYHOOOOOOOOOOWWWWWWWWWWWWWWWWWWMMMMMMQQQQQQXXXXXXXXXXXXXXXXQQQQQQQQQQQQQDDDDDBBBBBBBBBBBBBBBBBBZZRRRRRRREEEEEEEEEEEEJJJJJJJJJJJJ",
            "AAAARRRRRRRYYYOOOOOOOOOOOOWWWWWWWWWWWWWWWWLMMMMMQQQQQQQQXXXXXXXXXXXXXXQQQQQQQQQQQQQDDDDDDDDBBBBBBBBBBBBBBBZZZZRRRRREEEEEEEEEEEEEJJJJJJJJJJJJ",
            "AAAARRRRRRYYYVOOOOOOOOOOWWWWWWWWWWWWWWWWWWWWGGQQQQQQQQQQQXXXXCCXXXXXIIQQQQQQQQQQQYYEEDDDDDDBBUBBBBNBBBBBBBZZZZRRRREEEEEEEEEEEEEEEEJJJJJJJJJJ",
            "AAAARRRRRRYYYOOVOOOOOOOWWWWWWWWWWWWWWWWWWWWWGVQQQQQQQQQQQXXCXCCXIIIIIQQQQQQQQQQQYYEEDDYDDDHBBBBBHHBBBUBBBJZZZRRRRRREEEEEEEEEEEEEEEJJJJJJJJJJ",
            "AAARRRRRYYYYYYYVPOOOOOOOOOOWYYWWWWWWWWWWWWWWGVVQQQQQQQQQHHHCCCCCIIIIIQQQQQQQQQQYYYYYYYYDHHHHHHHHHBBBBBBBYJZZZZZRRREEEEEEEEEGGEEEDDDJJJJJJJJJ",
            "RAAARRRYYYYYYYPPPOPOOOOOOOOOYYYYWYWPWWWWSVVVVVVVQQQQQQQQHHHHHHNIIIIIIQQQIQQQQQJJJYYYYYYDHHHHHHHHBBBBBBBBBJJJJZRRRRRREEEEEEEGGEEEKKDKJJJJJJJJ",
            "RRRRRMRYYYYYYUPPPPPOOOOOOOOXXXYYYYYPPWWWPPVVVVVVVVQQQHHHHHHHNHNIIIIIIIIIIQQJJJJJJYYYYYYYYHHYHHHHHBBBBBBJBJJJJZRRREEEEEEEEEEGGEEEKKKKJJJJJJJJ",
            "RRRMMMYYYYYYYPPPPAPOOOOOOHXXXXYXYYYPPWPPPPVVVVVVVQHHHHCHHHHNNNNNNIIIIIIVJJJJJJJJJYYYYYYYYYYYYHHHHHHJJJJJJJJJJRRRRREXEEEEEEGGGGGGKKKKJJJJJJEG",
            "RRRMMMMYYYYYYPPPPOOOOOOOOXXXXXXXXXPPPPPPPPPVVVVVVVVVHHHHHHBNNNNNNNIIIIIVJJJJJJJJJYYYYYYYYYYAYAAHHAAAJJJJJJJJJEERRREEEEGGGGGGGGGGRRKKKJJJEJEE",
            "RRRMMMMMMYYYMMMPPOOOOOOBBXXXXXXNPPPPPPPPPPPVVVVVVDPPPHHHHHNNNNNNNNIIIIIVJJJJJJJJJYYYYYYYYYYAYAAHHAAJJJJJJJJEJXEERRRREGGGGGGGGGGGRRKKGGEJEEEE",
            "RRMMMMMMYYMMMMMPMMOOOOWWXXXXXXXXKKKKKPGPPPPPPPPPPPPPPPPHHHENENNNNNIIIIIJJJJJJJJJJYYYYYYYYYAAAAAAAAAJJJJJJJEEEEEERRRRRRTGGGGGGGGGGRGGGEEEEEEE",
            "RRMMMMMMMMMMMMMMMMMWWWWXXXXXXXXXKKKKKGGPPPPPPPPPPPPPPPPPHHEEEEENNNIIIIIJJJJJJJJJJJYYYYYYYYAAAAAAAAAJJJJJJEEEEEEEEERRRRTGZGGGGGGGGGGGGGEEEEEE",
            "RRRMMMMMMMMMMMMMMMWWWWWXXXXXXGGGGKGUUUGGGYPPPPPPPPPPPPPPPPEEEEEEEEIIIIIJJJJJJJJJJJYYYYYYYYYAAAAAAAAJJJJJJJJEEEEEEERRRRTGGGGGGGGGGGGGGGEEEEEE",
            "RRRMMMMMMMMMMMMMWWWWWWWWGGGGXGGGKKGGGGGYYYYPPPPPPPPPPPPPPPPPCCEEIIIIIJOJJJJJJJJJJJYYYYYYYYYAAAAAAJJJJJJJJJJEEEEEERRRRRTTGGGGGGGGGGGGGGEEEEEE",
            "RRRRRMMMMMMMMMMMMMWWWWWWGGGGGGGKKKGGGGGYYYYPPPPPMPPPPPPPCPPCCXXXXXXJJJJJJJJJJJJJJJYYYYYYYYYAAAAAAJJJJJJJJJJJEEEEETTRRTTTTGGGGGGGGGGGGGEEEEEE",
            "RRRRRMTMMMMMMLWWWWWWWWWWWWGGGGKKGGGGGGGGYPPPPPPPMPPPPPPPCCCCCCXXXXXXXXJJJJJJJJJJJQYYYYYYYYYAAAAAAAJJJJJJJJJJEEEETTTRTTTTTTTGGGGGGGGGGEEEEEEE",
            "RRRYYMTTMMMMLLWWWWWWWWWWWWWAGGGGGGGGGGGGYGPPPPPPMMPPPPPPCCCCCCCXXXXXXXXJJJJJJJJJJJJYYYYYYYAAAAAAJAJJJJJQQQEEEETTTTTTTTTTTIIIGGNGGGGGGEEEEEEE",
            "RRRYYMTTMMMMLLLLLWWWWWWWWWWAAAAGGGGGGGGGGGGPPPMMMAAAAPPCCCCCCXXXXXXXXXXXXXJJJJJJJYYYYYLLLLLAAAAAJJJJJJJJQQEEQETTTTTTTTTIIIIIINNGNGGGPEEEEEEE",
            "YYYYYYJTMMJMLLLLLLLWWWWWWWAAAAAAAGGGGGGGGGLMMMMMMAMAAPCCCDCCCCCDDDXXXXXXXXXJXXXJJYYYYYLLLLLLLANNNJNNJJJQQQQQQTTTTTTTTIIIIIIIINNNNNGGEEEEEEEE",
            "YYYYYYJTJJJLLLLLLLLWWWWWWZAAAAAAAGGGGGGGGLLLLMMMMMMAAPCCCDDCCCDDDDDDXXXXXXXXXXXWHHYHYLLLLLLLLLLLNNNNNJJQQQQQQTTTTTTCIIIIIIIIINNNNNNNEEEEEERE",
            "YYYYYYJJJJJLJJLLLLWWWWWWWAAAAAAAAAGGGGGGGLLMMMMMMMMCCCCCDDDDDDDDDDDMDXXXXXXXXXXXHHHHLLLLLLLLLLLLNNNNNNNQQQQQQQTCCCCCIGIIIIIIICCCCNEEEEEERRRR",
            "YYKKYYJJJJJJJJLLLLLWWWWJWAAAAAAAAGGGGGGGGLLMMMMMMMMXXXXDDDFDDDDDDDDDDXXXXXXXXXXHHHHHLLLLLSSLLLLLLLNNNNNQQQQQQQQQQCCCCCIIIIIIICCCCNNNEEEERRRR",
            "YYKKKYJJJJJLLLLLLLLLWWWLQAAAAAAZZZZZZZZGLLMMMMMMMMMMXXXDDDDDDDDDDDDDXXXXXXXXXXXHHHHHLSSSSSSSSLLLLNNNNNQQQQQQQQQQQCCCCCIIIIIIIICCCNNNNERRCRRR",
            "YYKKKJJJJJJLLLLLLLLLWWLLLAEAAAAZZZZZZZZMMMMMMMMMMMMMMMXDDDDDDDDDDDDDXXXXXZXXXXXTHHHLLLSSSSSSSSSSLLLLQQQQQQQQQQQQXXXCCCIIIIIIIICCCNNNNNRRRRRR",
            "YYKKKJJJJJJJLLLLLLLLLLLLLEEAAAAZZZZZZZZZTMTMMMMMMMMXXXXXDDDDDDDDDDDZXXXEZZVXXXOTTHHHLLSSSSSSSSSLLLLLLQQQQQQQQQOQXXXXXCCCCCICCCCCCCNRRRRRRRRR",
            "KKKKKJJJJJJJLLLLLLLLLLLLEEEEEAAZZZZZZZZZTTTTMMMMMMMMTTXXXDDDDDDDDDDZXXEEZZXXSSTTTTSHLLSSSSSSSSSSLLUULQQEEQEEQQQXXXXXCCCCCCCCCCCCCCNRRRRRRRRR",
            "KKKKKKKJKJJJJLLLLLLLNMLLEEEECZZZZZZZZZZZTTTMMMMMTTTMTTXXXDDDDDDDDDZZZZZZZSSSSSSSTSSSSSSSSSSSSSLLLLUUUUUUEEEEEEEXXXXXXCCCCCCCCCCCCRRRRXRRRRRR",
            "KKKKKKKKKJKKKKLLLLLLNNNNEEECCZZZZZZZZZZZTTTTTTTTTTTTTTTXXDDDDDDDDZZZZZZZZSSSSSSSSSSSMMSSISSSSLLKKKUUUUUUUUEEEXXXPPPPPCCCCCCCCCCZRRRRRRRRRRRR",
            "KKKKKKKKKKKKKKLLLLLLLNNNNNNCCCZZZZZZZZZZZZZZZTTTTTTTTTGXXXDDDVVZZZZZZZZSSSSSSSSSSSSSSMSSZZZZZZZKKUUUUUUUUEEEEXXXPPPPPCCCCZCZZZZZDDDRRRRRRRRR",
            "KKKKKKKKKKKKKKLLLLLNNNNNNNNNCCZZZZZZZZZZZZZZZXTTTGTTGGGGGXDDDVVZZZZZZZZSSSSZSSSSSSSSMMSMMZZZZZZKKDUUUUUUUPPPPPPPPPPPPCCCCZZZZZZTZZDRRRRRRRRR",
            "KKMMMMMMMMMMKKKLLLNNNNNNNNNNCCZJJJZZZZZZZZZZZXXXXGGGGGGGGDDDDVVVZZZZZZZZZZZZZSSSSSSSMMMMMZZZZZZKUUUUUUUUEPPPPPPPPPPPPCCZZZZZZZZZZZDZRRRRRRRR",
            "KKMMMMMMMMMMMMMMLNNNNNNNNNNNNCZJJJJJRRZZZZZZZXXXXFFGGGGGGGVVVVFVVFYZZZZZZZZZZSSSSSSSSSZZZZZZZZKKUUUUUUUUEPPPPPPPPPPPPXCCCZZZZZZZZPZZRRRYYRRR",
            "KKMMMMMMMMMMMMMMNNNNNNNNNNNNNNNNNJJJJRZZZZZZZXXXXXGGGGGGGGVVVVFFFFZZZZZZZZZZZZSSSSSSSSKZZZZZZZZKKYUUUUPPPPPPPPPPPPPPPUKRKZZZZZZZZZZIZRMRRRRR",
            "KKMMMMMMMMMMMMMMNNNNNNNNNNNNNNNNNJJJRRZZZZZZZXXXXGGGGGGGGGGVVVFFFFZZZZZZZZZZZSSSSSSSSSSZZZZZZZZYYYYYUUPPPPPPPPPUPPPPPUKKKZZZZZZZZZZZZQQORRRR",
            "KMMMMMMMMMMMMMMMNNNNNNNNNNNNNNNNNNJJJRZZZZZZZXXXXGGGGGGGGGVVVVVFFFZZZZZZZZZHHHSSSSSSTSZZZZZZZZZZYYYUUEPPPPPPPPPUPPPPPKKKKKKZZZZZZZZQMQQORRRR",
            "UMMMMMMMMMMMMMMMNLNNCNNNNNNNNNNNJJJVVRZZZZZZZZZZZZZGGGGGGVVVVVVFFTTJZZZZZZHHHHSSRRSTTZZZZZZZZZZZYYYYYEPPPPPPPPPUUUKKKKKKKKKZZZZZKKPPPPPPPPRR",
            "UMMMMMMMMMMMMMMMLLLLCNNNNNNNNNNNRRRRRRZZZZZZZZZZZZZGGGGGGGGVVVVVVVTZZZZZZZZHHHSHRRRZZJZZZZZZZSZYYYYYYYPPPPPPPPPKUKKKKKKKKKKNNNNOOOPPPPPPPPRR",
            "UMMMMMMMMMMMMMMMLLCCCCCCNNNNNNPPPRRRRRZZZZZZZZZZZZZGGGGGGGGGVVFVVVTTZZZZTTTEEHHHHZZZZZZZZZZZZSYYYYYYYYYPPPBBBUUKKKKKKKKKKKNNNNNNOOPPPPPPPPRL",
            "UMMMMMMMMMMMMMMMMLCCCCCGCCCNNPPPPPPPPRRRRVRVZZZZZZZGGGGGGGGGGGFFFFFTTZZTTEEEEEEHSSZZZZZZZZZZZZZYYYYYYYBPPPBBBKKKKKKKKKKKKKNOONNOOOPPPPPPPPQQ",
            "UMMMMMMMMMMMMMMMMMCCCCCCCCCCNPLLLPPPPPRRVVRVZZZZZZZGGGGGGGGLGFFFFFFTTTZTEYEEEEEHHSZZZZZZZZZZZZZZZYYYYYBPPPBKKKKKKKKKKKKKKOOOOOOOOOPPPPPPPPQQ",
            "UUMMMMMMMMMMMMMMMMCCCCCCDDCCULLLPPPPPPRUVVVVZZZZZZZGGGGGGGGGGFFFFFTTTTTTEEEEEEEEEEZZZZZZZZZZZZZSYYYYYYYPPPBBBKKKKKKKKKKKKOOOOOOOOOPPPPPPPPPQ",
            "UUUMMMMMMMMMMMMMMMMCCCCCCCCCUULLLPPPVVVVVVVVZZZZZZZGGGEEEEYYGFFFFFTTTTEEEEEEEEEEEEZZZZZZZZZZZZZYYYYYYYBPPPBBBKYKKKKKKKKKKOOOOOOWWWPPPPPPPPPQ",
            "UUUUMMMMMMMMMMGGGGMCCCCCCCCUULLLLLLPVVVVVVVVZZZZZZZGGEEEEEEEEFFFFFTTTTTEEEEEEEEEEEEEZZZZZZZZZZZWYYYYYYYPPPBBBBKKKKKKKKKKKFOOOOOWWWPPPPPPPPPQ",
            "GGUGMMMMZZMMMMGGGGTCCCCCCCCCUULLLLPPVVVVVVVVVFHHGGGTEEEEEEEEFFFFFFFFFTTTEEEEEEEEEEEEEZZZZZZZZZYYYMYYYYYPPPBBBBBBBKKKKFFFFFOOOOOWWWWWLLPPPPPF",
            "GGGGGMMZZZZZZZGGGGTTCCCCCCUUUULLLLPPRVVVVVVVFFHHGGGEEEEEEEEEFFFFFFFFTTTTEEEEEEEEEEEEEZZZZZZZZZCYYYYYYYYYBBBBBBBBBKKKKKFFFKOOOOWWWWWWMMPPPPPF",
            "UGGGGDDZZZZZZMGGGGTTEECCCCUUULLLLLLPPZVVVVVVFFFFEGGEEEEEEEEEFFFFFFUYUETTEUEEEEEEEEEEEEZZZZZZZZCCCCYYYYYYBBBBBBBFBBBKFFFFFKKOOKWWPPPPPPPPPPFF",
            "GGGGGGGGGGGGGGGGGGTEEEEECCCUULLLLLZZZZZFFVFFFFFFEEEEEEEEEEEEFFFFFUUUUEEEEEEEEEEEEEEEEEEEZZZZCCCYYYYYYYYYBYYBBBFFFBBKFFFKKKPPPPPPPPPPPPPPPPFF",
            "GGGGGGGGGGGGGGGGGGTPEPECCCUUUUUULZZZZZZFFFFFFFFFEFEEEEEEEEEEEFFFFFUUUEZEEEEEEEEEEEEEEEEEEZZCCCYYYYYYYYYYYYYYQFFFFKKKFFFFFKPPPPPPPPPPPPPPPPFF",
            "GGGGGGGGGGGGGGGTTTTPPPPPUUUUUULLLLZZZZZFFFFFFFFFFFEEEEEEEEEEEFFFFFFUUUZEEELEEEEEEEEEEEEEEECCCCYYYYYYYYYYYYYYQQFFFFFKFFFKKKPPPPPPPPPPPPPPPSSF",
            "ZGGGGGGGGGGGGGGTTTKPPPPPQUUULLLLLLLLLLLILFFFFFFFFFFFFEEEEEEEEFFFFFFFUUUUUUUTEEEEEEEEEEEEEEECVCCYYYYYYYYYYYYYQFFFFFFFFFFFFKPPPPPPPPWWWWWWWWSS",
            "GGGGGGGGGGGGGGGTTKTPPPPQQQUQBBLLLLLLLLLLLFFFFFFFFFFFFEEEEEEEBHFFFFYYUUUUUUUTEEBBBBBBBBBEEEECVCCYYYYYYYYYYYYQQQFFFFFFFFFFFKPPPPPPPPWWWWWWWWSS",
            "GGGGGGGGGGGGGGGTTTTQQQPQQQQQQQJJLLLLLLLLFFFFFFFFFFFFEEEEEEEEHHHFXFUUUUUUUUUTEEBBBBBBBBBEECCCVCCYYYYYYYYYYYYYQQQQFFFFFFFFFFPPPPPPPPWWWWWWWWSS",
            "GGGGGGGGGGGGGGGTTTTQQQQQQQQFFLLLLLLLLLLLLFFFFFFFIFYYPPEEEHHHHHHHUUUUUUUUUUUEEEBBBBBBBBBEEEVVVCCYYYYYYYYYYYYYQQQFFFFFFFFFFFPPPPPPPPWWWWWWSSSS",
            "GGGGGGGGGGGGGGGTTTTQQQQQQQQQFLGLLLLLLLLLLFFFFFFFCFYCPPEHHHHHHHHDUUUUUUUUUUUUUEBBBBBBBBBEEEVVVCYYYYYYYYYYYYYYYFFFFFFFFFFFFFPPPPPPPPWWWWWWSSSS",
            "GGGGGGGGGGGGGGGTTTTQQQQQQQQFFLLLLLLLLLLHFFFFFCCCCCCCPPPPPPHHPZZDDUUUUBBBBBBBBBBBBBBBBBBEEETEVVVVVVVYVYYYYYKKKKKFFFFFFFFFFFPPPPPPPPWWWWWWSSSB",
            "GGGGGGGGGTTTTTPTTTTTTQQQQQQQQELLLLLLLLLHHCFFFCCCCCCCPPPPPHHHPPZDDDDUUBBBBBBBBBBBBBBBBBBEEEEEEVVVVVVVVVYYKKKKYKKKFFFFFFFFFFFFMMWWWWWWWWWWDSSB",
            "AAAAGGGGGSXTTTPTHHHHHQQQQQQQEEEELLLLLLLHCCCCCCCCCCCCPPPPPPPHPTDDDDDUABBBBBBBBBBBBBBBBBBEEEEEEVVVVVVVVVYYYKKKYYKKKFFFFFFFFFMMMMWWWWWWWWWWDDSB",
            "AAAAGGGGGSXTDDSAHUHHHQQQQQEEEEEEELLLZZLHCCCCCCCCCHHPPPPPPPPPPDDDDDDDDBBBBBBBBBBBBBBBBBBBBBBVVVVVVVVVVVVYYKKKYOYKKFFFFFFMMMMMMMWWWWWWWWWWDDSB",
            "AAAAAASSSSSSSSSHHHHHHHHQQQEEEEEEELLLZZZCCCCCCCCCCHHPPPPPPPPPDDDDDDDDDBBBBBBBBBBBBBBBBBBBBBBVVVVVVVVVVVVYYKKYYYYKFFFJQFFQNNNNMMWWWWMWWWWWMDSB",
            "AAAAAASSSSSSSSSHHHHHHHQQQQEEEEEENNZZZZZCCCCCCCCCHHHHHPPPPPPPDDDDDDDDDBBBBBBBBBBBBBBBBBBBBBBNVVVVVVVVVVVYYYYYYYKKKKJJQQQQNNNNMMWWWWMMMMMMMMBB",
            "AAAAAASSSSSSSSSSHHKKHKKQQEEEEEENNNNZZZZCCCCCCCCHHHHHPPPPPPPPDDDDDDDDDBBBBBBBBBBBBBBBBBBBBBBBVVVVVVVVVVVYYYYYYYYYYKJJJJJNNNNNNRWWWWMMMMMMMBBB",
            "AAAAAASSSSSSSSSSHHKKKKKQQQEEERRNNNNZZZZZCCCCCCCCHPPPPPPPPPDDDDDDDDDDDBBBBBBBBBBBBBBBBBBBBBBBBVVVVVVVVVVYHYYYYYYYFJJJJJJNNNNRRRWWWWMMMMMMMBBB",
            "AAAAASSSSSSSSSSSXHKKRRQQQQEEEERRNZZZZZLZZZKKKCCPPPPPPPPPPPPPOODDDDDDDDDDDGGGTTBBBBBBBBZZZBBBBBVVVVVVAAAAAAYYYYVYJJJJJJJNNJNRCCWWWWMMMMMMMBBB",
            "AAAAASSSSSSSSSSSRRRRRRRBQEERRRRZZZZZLLLZZLKKKKPPPPPPPPPPAAAYAODDDDDDDDDDDGGGTTBBBBBBBBBBBBBBBBVVVVVVAAAAAAYYYYYJJJJJJJJJJJJCCTWWWWMMMMMMMBBB",
            "ALAVVSSSSSSJSSSSRRRRRRRRARRRRRRRZZZZZZLLLLKKKKPPPPPPPPAAARAAADDDDDDDDDDDDDGGTTBBBJJBBBBBBBBBVVVVVVVAAAAAAAAYYYYJJJJJJJJJJCCCCCWWWWMMMMMMMMBB",
            "VVAVVVVSSSVSSSSSZRRRRRRRRRRRRRZZZZZZZLLKLLKKKKKKPPKPPPAAAAAAAADDDDDDDDDDGGGGTTBBBAABBBBBBBBBVVVAAAAAAAAAAAAYJJJJJJJJJJJJJCCCCCWWWWMMMMMCMCCC",
            "VVVVVVVVVVVVSVOSRRRRRRRRRRRRRZZZZZZZZEGKKKKKKKKKKKKPAAAAAAAAAADDDDDDDDDDGGGTTTGAAAABBBBBBBBBVXVZAAAAAAAAJJJJJJJJJJJJJJGJJVCCCCWWWWMMMMCCCCCC",
            "ZZVVVVVVVVVVVVOOORRRRRRRRRREEEEEEEZZEEKKKKKKKKKKKPPPEAAAAAAAAACCDDDDDDDDGGTTTTAAAAAABBBBBBBIIAAAAAAAAAJJJJJJJJJJJJJJJJGGGGCCCCCCCCCMMCCCCCCC",
            "ZZZVVVVVVVVVVVZZZRRRRRRRREREEWEEEEEEEEEKKKKKKKKKKPPPEAAAAAAAACCCAADDDDDGGGTTTTAAAAAABBBBBBBIIIITAAHHHAAJJJJJJJJJJJJJGJGGGGGCCCCCCCCCCCCCCCCC",
            "ZZZVVVAAVVVVVZZZZRRRRRRRREEEEWEEEEEEEEEKKKKKKKKKFPPPEEEEEEAACCCCUUZZZDDQQQTTTAAQQQQQABDBBBBIITTTAHHHAAAJJJJJJJJJJLGGGGGGGGGGGGCCCCCCCCCCCCCC",
            "ZZZZVVAAAVZVZZZZZZERRTRREEEEEEEEEEEEEEEKKKKKPPPFFPPPEBEEEECCCCCUUUZZZZQQQTTTTQQQQQQQABBBHBJTTTBTTHHHHHHHJJJJJJJJLLGFGGGGGGGGGGCCCCCCCCCCCCCC",
            "ZZZZVZGGZZZZZZZZZZZZTTRRREEEEEEEEEEEEEEKKKKPPPPPFPPPPBKEEECCCUCCUUZZZZQQQQQQQQQQQQQQAUUUWWWTTTTTGHAHXXHJVCJVVJJLLLLGGGGGGGGGGGGGGGCCCCCCCCCC",
            "ZZZZZZZGZZZZZZZZZZZQQTTTREEEEEEEEEEEEEEEKKPPPPPPPPPPPBKCECCCCUCCUUZZZZQQQQQQQQQQQQQQQQUUUJWWWTTTHHHHHHHHVCVVVVVLLVLVGGGGGGGGGGGGPGCCCCCCCCCC",
            "ZZZZZZZGZZZZZZZZZZZZQTTTQEEEEEEEEEEEEEEEPPPPPPPPPPPPPBKCCCCCUUUUUUZZZZQQQQQQQQQQQQQQQQUUWWWWWTTTHHHHHHHHVVVVVVVVVVVVGGGGGGGGGGRRRCCCRCCRCCYC",
            "ZZZZZZZZZZZZZZZZZZZQQTQQQQEEQEEEEEEEEEEEEPMPPPPPPOOPPKKCCUUUUUUUUUQQQQQQQQQQQQQQQQQQQQUUUWWWMMTTTMMHHHHHVVVVVVVVVVGGGGGGGGGGGRRRRRCCRCRRCCYF",
            "ZZZZZZZZZZZZZZZZZZQQQQQQQQQQQEEEEEEEEEEEEPPPPPPPPOOKKKKCCURBRRUUUQQQQQQQQQQQQQQQQQQQQQUUWWWMMMMMMMMHHHHVVVVVVVVVVVGGGGGGGGGGGGGGRRRRRRRRYCYY",
            "ZZZZZZZZZZZZZZZZQQQQQQQQQQQQEEEEEBDEEEEEEDPPPDDPKKKKKKKKCRRRRIRUUCQQQQQQQQQQQQQQQQQUUUUUWWMMMMMMMMMMHHHXXVVVVVVVVVGGGGGGGGGGGGGGRRRRRRRYYYYY",
            "ZZZZZZZZZZZZZVVZQMMMQQMYQQQQEEEEEEDDEEEEEDPDDDDDKKKKKKCCCRRRRRRURCQQQQQQQQQQQQQQQQQUUUUUWWMMMMMMBBBBBHBXXVVXVUUKKKKGGGGGGGGGGGGGGRRRRRRRYYYY",
            "ZZZZZZZZZZZZMMVMMMMMMMMYYQYYHHEEDDEEEEEEEDDDDDDDKKKKKKKKCCRRRRRRRCCQQBOOQQQQQQQQQQQUUUUUUUUUMMBBBBBBBBBXXXXXXUUUUKGGGGFFGGGGGGGRRRRRRYYYYYYY",
            "ZZZZZZZZZZZWMMVMMMMMMMYYYYYYYHHHHHEEEEEDDDDDDDIDKKKKKKKKKCRRRRRRCCCQBBBBBBBBQQQQQQQQUUUBUUUMMBBBBBBBBBBXXXXXUUUUUULUFGFFGGGGGGGRFRYYYYYYYYYY",
            "ZZZZZZZZZZZWMMMMMMMMMYYYYYYYYHHHHDEEEEEDDDDDDDKKKKKKKKKKKCCCCRCRCCCIVBBBBBBBQQQQQQUUUUUBBBMMMMBBBBBBBBBXXXXUUUUUUUUUUFFFFGGGFGFFFFFYYYYYYYYY",
            "ZZZZZZZZMMMMMMMMMMMMMYYYYYYYHHHHHDDDDDDDDDDDDDKKKKKKKKKCCCCCCRRRCCCIBBBBBBQQQQQQQQUUVNNNBBBMMMBBBBBBBBBXXXXUUUUUUUUUUFFFFFFFFFFFFFFYYYYYYYYY",
            "ZZZZZZZZZMMMMMMMMMMMYYYYYYYYHHHHYYKDDDKKDDDDDDKKKKKKGGKCCCCCCCCCCCCIIBBBBBBQQQQQOGUUVNNNBBBBNNBBBBBBBBBBXXXUUUUUUUUUUFFFFFHHHHFFFFYYYYYYYYYY",
            "ZZZZZZZZZMMMMMMMMMYYYYYYYYYYYYYYYYKDKDKDDDDDKDKKKKKKGGGGCCCCCCCCCCIIBBBBBBBBQQQOOOOONNNNBNNBNNNNBBBBBBBXXXUUUUUUUUUUUFFFFHHHHFFHHFHYYYYYYYYY",
            "ZZZZZZZZZMMMMMMMMYYYYYYYYYYYYKKKKKKKKKKDDDDKKKKKKGGKGGGGGCCCCCCIIIIIBBBBBBBBQQQQOOOENNNNNNNNNNNNBBBBTTBXXXUUUUUUUUUUUFFFFFFHHHFHHHHBYYYYYYYY",
            "ZZZZZZZZZMMMMMMMMYCYYYYYYYYYYYYKKKKKKKKKKKKKKGKKGJGGGGGGGGGGCCCOIIIBBBBBBBBBBKQOOOOOONNNNNNNNNNZBBBBBTTTTTUUUUUUUUUUFFFFFFHHHHHHHHHYYYYYYYYY",
            "ZZZZZZZZMMMMMMMMYYYYYYYYYYYBYBBWWWKKKKKKKKKKKGGGGGJGGGGGGGGGGCOOOBBBBBBBBBBBKKKOOOOOONNNNNNNNNNNBBTTTTTTTTAUUUUUUUUUFFFFFFHHHHHHHHHHHYYYYYYY",
            "ZZZZZZZZOOOMZMMZZZYYYYYYYYBBBBBWWWWKKQKQKKKKGGGGGGGGGGGGGGGGGCOOBBBBBBBBBBBKKKOOOOOOONNNNNNNNNNNBBTTTTTTTAAUUUUUUUUFFFFFFFFFHHHHHHHHHYYYYYYY",
            "ZZMZMZZOOOOOZMMZZZYYYYYYYYYBBBBWBWWKQQQQQKKKGGGGGGGGGGGGGGFGFFFOOOOBOOBBBBBBKOOOOOOOONNNNNNNNNNNNBBBTTTTTTTUUUUUUUFFFFFFFFFFFFHHHHHHHYYYYYYY",
            "ZLMMMOOOOOOOZZZZZYYYYZYYYYYBBBBBBBWKKKQQQQKKKKGGGGGGGGGGGGFFFFFFOOOOOOOBKKKKKOOOOOOYYNNNNNNNNNNNNNNNTTTTTVTTOFFFFUFFFFFFFFFFFHHHHHZZZZYYYYYY",
            "MMMMMOMMOOOOBZZZZZYYZZYZBBBBBBBJBHWHQQQQTTTKKKKGGGGGGGGGGFFFFFFFOOOOOOOBKKKKKOOOOGOXYYNNNNNNNNNNOEOOTTTTTTOOOOFFFFFFFFFFFVVFFFHZZZZZZZYZYYYY",
            "MMMMMMMMOOOOBZZZZZZYZZZZZZZBBBJJJHWHQQQQTTTTTGGGGGFFFGGGFFFFFOOOOOOOOOOOHHHHHGGGOGGXYYYNNNNNNPPPOOOOOOTOOOOOOOFFWWWWFFFFFFVVVZZZZZZZZZYZYYYY",
            "MMMMMMMMOOOOBZZZZZZZZZZZZZZBJJJJJHHHHQQTTTTTTTDGGFFFFFFFFFFFFOOOOOOOOOOHHHHHGGXGGGGXXYYNNNNNPPPPPPOOOOOOOOOOOFFWWWWFFFFFVVVVVZZZZZZZZZZZZYYY",
            "MMMMMMMOOOOBBZZZZZZZZZZZZZZZJJJJJHHHHHTTTTTTTTDDDDFFFFFFFFFPPFOOOOOOOOOHHHKKXXXXXXXXXXNNNNNNPPPPPPOOOOOOOOOIOOOOWWWWWWFFFVVVVZZZZZZZZZZZZYYZ",
            "MMMMMMOOOBBBBZZZZZZZZZZZZZJJJJJJJHHHHTTTDTTTTDDDDDFFFFFFHFFFFFOOOOOYOOHHHHHXXXXXXXXXCXXNGGNPPPPPPPOOOOOOOOIIIWWWWWWWWWWWFVVVVZZZZZZZZZZZZZZZ",
            "MMMMMMOOBBBBBBZZZZZZZZZZZZZZJJJJJJJJHHHTDTTTTDDDDDFFFFFFFFFFFOOOOOOYYHHHHHXXXXXXXXXXXTUUUUNPPPNPPOOOOOOOOOOIWWWWWWWWWWWWWWWZZZZZZZZZZZZZZZZZ",
            "MMMMMMMOOBBBBBBBZZZDDDZZZJJJJJJJJJJJHHHDDTTTTDDDDDFFFFFFFFFFFOOOOOYYYHHHHHHHXXXXXXXXXTUUUNNNNNNNOOOOOOOOFFRRWWWWWWWWWWWWWRRRZZZTZZZZZZZZPZZZ",
            "MMMMMMMBBBBBBBBBZZZZDDDDJJJJJJJJHHJHHHHDDDDDDDDDDDFKFFFFFFLFFFOOOOYYYYHHHHHHXXXXXXXXXXUUUNNNNNNNNOOFFFFFFRRRRRWWWWWWWWWWWWWRRZZTZZZZZZZZPZPP",
            "MMMMMMMMMBBBBBZZZZZDDDDDDDEJJJJJHHHHHHHDHDDDDDDDDFFKFFFFFFFFFOOOOOOYYYYHHHHHCXXXXXXXXUUNNNNNNNNNNNNFFFFFFRRRRRWWWWWWWWWWRWWRZZTTZZIPPZZPPPPP",
            "MMMMMMMMBBBBBBZZZZDDDDDDDDDJJJJJHHHHHHHHHDDDDDDDDFFFFFFFFFFFOOOOOODDYYYYHHHHCCXXXXXXXUUUUNNNNNNNNNNFFFFFFSRRRRRWWWWWWWWRRRRRZZZZZPIPPPPPPPPP",
            "NMMMNMNMBBBBBBBZZZZZDDDDDDDHJHHHHHHHHHHHRHDDDDDLFFFFFFFFFFFFOOOOODDDYYYYHYYYYXXXXXXXXXUUUNNNNNNNNNNNFFFFSSSSRRWWWWWWWWWRRRRRZZZZPPIPPPPPPPPP",
            "NNNMNMNNBBBBBBBBZZZZPDDDDDDHHHHHHHHHHHHHHHLLLLLLLZFFFFFFFFFFOOOOODYYYYYYYYYYYYXXXXXXXXUUUUNNNNNNNNNFFFFFSSSSSSKKWWWWWWWRRRRRZZZZPPPPPPPPPPPP",
            "NNNNNNNNNBBBBBBBZZZZZDDDDDDHHHHOHHHHHHHHHHHLLLLLLZZFFFFFFFFFFOOYYYYYYYYYYYYYYYYXXXXXXUUUUUNNTNNNNNFFFFFFFSSSSSSWWBWWWWWWZRZZZZZZZZPPPPPPPPPP",
            "NNNNNNNNNBBBBBBBBZZZZZDDDDDHHHOOOOHHHHHHHHHHHLLLFFFFFFFFFFFFFOOYYYYYYYYYYYYYYYYXXUJXXUUUUUUNNNNWWFFFFFFSSSSSSSSSSWWWWWWWZZZZZZZZZZPPPPPPPPPP",
            "NNNNNNNNBBBBBBBUUUZZZZDDDDHHHOOOOOHHHHHHHHHHHHHHHHFFFLFFOOOOOOOOOYYYYYYYBOYYYYYYYUUXUUUUUUUNNWWWFFFFFFFFFSSSSSSSSSSWWWZWZZZZZZZZZZZPPPPPPPPP",
            "NNNNNNNNNBBBBBBBKUKRKKKDDHHHHHOOOOHHHHHHHHHHHHHHHHHFFFFFOOOOOOOOOOOZYYRYOOOYYYYYYUUUUUUUUUUUUUWWWFFFFFFFSSSSSSSSSSWWWZZZZZZZZZZZZZZZPPPPPPPP",
            "NNNNNNNNYBBJBBXXKKKRKKPPPHHHHHHOOOOOHHHHHHHHHHHHHHIFFFFFOOOOOOOOZZOZYYLLOOOOOOYOUUUUUUUUUUUUUUWFFFFFFGGQQSSSSSSSSSSSWZZZZZZZZZZZZZZPPPPPPPPP",
            "NNNNNNXBBBBBXXXKKKKRKKPPHHHHHHHOOOOOHHHHHHHHHHHFFFFFFFFFKOOOOOZOZZZZZZLLLLOOOOOOCUUUUUUUUUUUUUWWWVFFFFGGGSSSSSSSSSSSSSSZZZZZZZZNNNBPPPPNPPPP",
            "NNNNNNBBBBBXXKXKKKKKKKKHHSHHHHOOOOOOHHHHHHHHHHHHHHFFFFZKKOKKZZZZZZZZZLLLLOOOOOOOCUUKUUUKUUUXVUWVVVVGGGGGGGGSSSSSSSSSSSSZZZZZZZZZNBBBPNNNNPPP",
            "NNNNNTTTBBBXXKKKKKKKKKSHHSHHHHHOOOOOOOHHHHHHHHHHHHFFFFZKKKKKZZZZZZZZZZLLLLLOOOOOOOKKUKKKUUVVVVVYVVVYGGGGGGGGSSSSSSSSSSSSZZZZZZZZNNNBPNNNSPPP",
            "NNNNNTTTTMBXKKKKKKKKKKSHSSSHHHHOOOOOOOHHHHHHHHHHHHHFZZZKKKKEEEZZZZZLLLLLLLLOOOOOKKKKUKKZUVVVVVVVVVVYGGGGGGSSSSSSSSSSSGGGGGGZZZZZNNNNGNNNNPNN",
            "NTTNTTTTTTBXKKKKKKKKKKKKSSSHHHXOOOOOOPFFHHFHHFHHHHHZZXZZKKKEEEEEZPUULLLLLLLOOOOOZKKKKKZZCVVVVVVVVVVGGGGGGSSSSSSSSSSSSGGGGGGZGZZZNNNNNNNNNNNN",
            "TTTNTTTTTTTTKNKKKKKKKKKKKKKVPHPFFOOOPPFFHHFFHFHHHHZZZXXXEEEEEEEEPPPUULLLLLOOOOOOZZKKZZZZZQVVVVVVVVVMGGGGGGMMMMSSSSSSSGGGGGGGGGZNNNNNNNNNNNNN",
            "TTTTTTTTTTTITTTKKKKKKKKKKKKVPPPPPPPPPPFFFFFFHFFFFFXXXXEEEEEEEEPPPPPLLLLLLLLOPOCCZZKZPZZZZVVVVVVVVVVMMGGGGGMMMMSSSSGSSGGGGGGGGGZNNNNNNNNNNNNN",
            "TTTTTTTTTTTTTEEEKKKKKKKKKKKPPPPPPPPPPPPFFFFFFFFFFFXXXXXXEEEEEPPJPPPLPPLLPPPPPPCZZZZZZZZZZVVVVVVVVVVMMMGGMMMMMSSGSSGGGGGGGGGGNZZZUNNNNNNNNNNN",
            "TTTTTTTTTTTTTFEEEKKKKKKKKKKPPPPPPPPPPPPFFFFFFFFFFXXXXXXXXEEEXPPPPPPLPPPLPPPVPCCPZZZZZZZZZZVVVVVVVVVVMMGGMMMMMGGGGGGGGGGGGGGGNNNUUNNNNSNNNNNN",
            "TTTTTTTTTTTTFFFEEFKKKKKHKKKPPPPPPPPPPPPFPPFFFFFFFXXXXXXXXEXXXOOPPPPPPPPPPPPPPPPPZZZZZZZZZZZVVVVVVMMVMMMMMMMGGGGGGGGGGGGGGGGGNNNNNNNSSSSNNNNN",
            "TTTTTTTTTTTTTFFFFFZKKKWLLLKGPPPPPPPPPPPPPFFFFFFXXXXXXXXXXXKXXXPPPPPPPPPPPPPPPPPPZZZZZZZZZZZZVVVMMMMMMMMMMMMGGGGGGGGGGGGGGGGGGNNNNNNNSMSSNNNV",
            "TTTTTTTTTTTFFFFFFFFFFFLLLLPPPPPPPPPPPPPFFFFFFFFFXXXXXXXXXXXXXXXPPPPPPPPPPPPPPPPPZZZZZZVZZZZZZZVMMMMMMMMFMMGGGGGGGGGGGGGGGGGGGNNNNNNNNMNSNVVV",
            "TTTTTTTTKKKKFFFFFFFFFFLLLLLLZPPPPPPPPPPFFFFFFFFFXXXXXXXFXXSSSXPPPPPPPPPPPPPPPPPPZZZZZVVVZVZZZMMMMMMMMMFFFFFGGGGGGGGGGVGVVVVVGNNNNNNNMMNNNNNV",
            "TTTTTTTKKKKKKFFFFFFFFFLLLLLLZZYYPPPPPPPPFFFFFRRFXXXXXXFFXXSSSSPPPPPPPPHPPPPPPPZZZZZZZQVVVVVVZMMMMMMMMMFFFFFGGGGGGGGVVVVVVVVNNYNNNNNYSSSSSSNS",
            "TTTBBBBBKKKKFFFFFFFFFFFLLLLLLLYYYPQQPYPPFFFFRRRRRXXXXXFFFTTSSSPPPPPHHHHHPHPPJJJBLBBBVVVVVVVVMMMMMMMMMMFFFFFFGGGGGGNNVVVVVVVNYYYYYYYYSSSSSSSS",
            "TTBBBBBBBBKFFFFFFFFFFFLLLLLLLYYYYYQYYYYFFFFFFRRRRXXXXXXXFTTTTDDDDHHHHHHHHHHHHJJBBBBBVVVVVVVVVMMMMMMMKFFFFFFFFGGGGGNNVZZVVVNNYYYYYYYSSSSSSSSS",
            "BBBBBBBBBYKFFFFFFFFFFFLLLLLLYYYYYYYYYYFFFFRRRRRRRRRXXXXFFFTTDDDDDHHHHHHHHHHHHHBBDKBBVVVVVVVVMMMMMMKKKFFFFFFFFFFGFGNNNVVVVVNNYYYYYYSSSSSSSSSS",
            "BSBSSSSUYYKFFFFFFFFFFLLVVVVYYYYYYYYYYYFFFFFRRRRRRRRRRGXTTTTTTDDDDIHHHHHHHHHHDDDDDKKKVVVVVVVVMMMMMKKKKKKTFFFFFFFFFNNNNVVVVVNTTRYPYYSSSSSSSSSS",
            "SSSSSSSSYYYYYYFFFFFFFVLVVVVVVYYYYYYYYYYFFFFRRRRRRRRRRRTTTTTTTTDDDDDHHHHHHHHHHDDDKKKKVVVVVVVVVVMMMMKKKTTTFFFFFFFFFFNNNNNVVVNNTRYYYSSSSSSSSSSS",
            "SSSSSSSUUYYYYYFFFFFHVVVVVVVVVVYYYYYYFFFFFFRRRRRRRRRRRRRTTTTTTTDDDDDDHHHHHHHHQHKKKKKKVVVVVVVSSMMMMMMEEETMFMVVYXFAAFNNNNNNVNNNTTTTYSSSSSSSSSSS",
            "SSYSSSUUUYYYYYWFFFFVVVVVVVVVVYYYYYYYFFFRRRRRRRRRRRRRRRRTTTTTTTDDDDDDDDDDHHHHHHKKKKKKKVVVVVSSSMMMMMMEEEMMMMYYYYFAAAYNNNNNNNTNTTTTSSSSSSSSSSSS",
            "SSSSSSSSUYYYYNSFFFFVVVVVVVYYYYYYYYYYKFFRRRRRRRRRRRRRRRTTTTTTTDDDDDDDDDDDHHHHHIKKKKKKIIIVVVSESMMMMMMEMMMMMMMYYYYYAAYNNNNNTTTTTTTTTSSSSSSSSSSS",
            "SSSSSSCCYYYNNNSSSSSGGVVVVEEYYYYYYYYYKFFRRRRRRRRRRRRRRRTTTTTDDDDDDDDDDDDTHHHHHIKIKKIIIIIIIIEEMMMMMMEEEMMMMMMYYYYYYYYNYNNNTTTTTTTTYYSSSSSSSSSS",
            "SSSSSSCCCCIIIIGGSSSGVVVVVVVYYYYYYYYYKFFIIRRRRRRRRRRRRRRRTTTTTDDDDDDDTTDTHHHAHIIIIIIIIIIIIIIEEMEEEEEEEMMMMLYYYYYYYYYYYYNNNTTTTTYTYXYMSSSSSSSS",
            "SSSSTTCTCIIIIIIISSGGGVVVOOOOOYYYYYYYYIIIIIRRRRPRRRRRTRRRTTTTTDDDDDDDTTDTTHBAAIIIIIIIIIIIIIIEEEEEEEEEEEMMMMYYYYYYYYYYZZNNNTTTTTYYYXYMSSSSSSSS",
            "TTTTTTTTTIIIIIIIIGGGGGVVVVYYYYYYYYYYYIIIIIRRRRRRRRRRRRRTTTTTTTDDDTDDDTTTTAAAAAIIIIIIIIIEEIEEEEEEEEEEEEMMMMMMMYYYYYYYZZZZZZZTTTYYYYYYYSSSQSSS",
            "TTTTTTTTIIIIIIIIIGGGGGVVVVGGYYYYYYYYYIIIIHTRRRHRRRRRRRHTTTTTTTTTDTTTTTTTTTAAAAIIIIIIIIIEEEEEEEEEEEEEEEMMMMMYYYYYYYYYYZZZZZZTTTTYYYYYSSSSQSSS",
            "TTTTTTTTIIIIIIIIIIIGGGGGGGGGGYYYYYYYIIIIIHRRRHHHRRRRRRHTTTTTTTTTTTTTTTTTTTAAIAIIIIIIIIIIEEEEEEEEEEEEEEMMMMMMYYYYYYYYYYTZZZTTTTTTTYYYYYSSSRSR",
            "TTTTTTTTIIIIIIIGGGGGGGGGGGGGYYYYYYYYYIIIIHHHHHHHHHHHHHHHHHTTTTTTTTTTTTTTTAAAIIIIIIIIIIIEEEEEEEEEEEEEEEEEEEMYYYYYYYYYYYTXZZTTTTTTTTYBYRSRRRSR",
            "TTTTTTTXIIRIRIIIGGGGGGGGGGGGYYYYYYEYIIIIIHHHHHHHHHHHHHHHHHHTTTTTTTTTTTTTAAAIIIIIIIIIIIEEEEEEEEEEEEEEEEEEEEMYYYYYYYYYTTTTTTTTTTTTTTBBYRRRRRRR",
        ];
    }
}