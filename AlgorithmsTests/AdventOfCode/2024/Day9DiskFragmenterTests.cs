using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.AdventOfCode._2024;

[TestClass]
public class Day9DiskFragmenterTests
{
    #region Part 1

    [TestMethod]
    public void CalculateChecksum_SampleMap_PerformsCorrectly()
    {
        // Arrange
        Day9DiskFragmenter day9DiskFragmenter = new();
        var diskMap = _getSampleMap();

        // Act
        var actual = day9DiskFragmenter.CalculateChecksum(diskMap);

        // Assert
        actual.Should().Be(1928);
    }

    [TestMethod]
    public void CalculateChecksum_TestMap_PerformsCorrectly()
    {
        // Arrange
        Day9DiskFragmenter day9DiskFragmenter = new();
        var diskMap = _getTestMap();

        // Act
        var actual = day9DiskFragmenter.CalculateChecksum(diskMap);

        // Assert
        actual.Should().Be(6279058075753);
    }

    #endregion

    private string _getSampleMap()
    {
        return "2333133121414131402";
    }

    private string _getTestMap()
    {
        return "2167564911693583923981294757547434131091649637522159677481959069745486754969611027658022544225548256354654593131155189269373657676583024578939673784882474419063637858754957669060768080452152645113351797143279555088348056235542147248279490341816604332775662244111358689906240727858421523318967751831755732659970527810103117704236231124952936558212456399467636815131408730628418668713641225335884589731632590976531503777127926592447916317178186368587916637453853849731853783163412127868521246216858516080918546496187757037248361981979798133484735805826709498503250942855284647627953205674936989726066461118449473366410104946676477964973994421688735775525942086159545127527116791675912553522331533307829203974341547555882672621528022654121675832515667254319175435919776194255986840458074825917879356504599182781855173226645862838107279897873498995754416221471937952662546658292164717324240238531973838767654824744584981565084879551413380599060648597563945575567143169755510453843504465121226316672438833592269879543539131382156524248547258434474166814343952768518523723544047299924514116136523578171758079469718144490555949744661229320333860471048868999928054645040377154338756629866301172912167571034495321472850473085372597431238505856208855183022833136493186649250271194433368556025246212681776352421529674472224578155302427165571111925124976553978895447861179569279637522392047468561456590195730558911363226199548323254817658121460446877639816781569991415995269851775153246917994909836647812583574845725594443872974103124273580704691813813309087396948854153982845137684419032102399593812203740367750469117934942251871864835569551848293523432191965558716879299317068432162872432888415916864759855114463716431856811841874312614286577556921584376518540893930737978391592309997312763193848305253897730396019585586584038577857671488709224979664529346286348376474415569133217948711687944692871177589438442271579981080951120323773895180981291672426301298216459103323535464267933969279871851588661916095774452807242566031397968898261887963314629402390542841394083896787184553641749506179451719987236456799701610499790159251136832436945875871318796187425897615589353862350207245408765987043877131303636521836739281675295407658176831608827714040754333162519819790731077748231567953575952384388295814367382836451733689459626904445208963271980533215512944221055532127496382528226639543986125357116447550146913549032565592425510324129232740562927987655886728281650532534686255869670449662976842129437765782208816252436393733136696544828569566997237583734337482317263633865964059644547453499609775387681457081736664407966766777972439535397522763149155987056371212672956488981593396225564694881885857617135347635557940817258612315617982283578836293676479408123977540311950866797692794946266704658757866128386324630358337276237427350845337128942471562613896819753775233856040527616582759278075789899591173801047281249781783481296948844501442666641159724604424547799595959958335237879718996696552294951552258941671757956278172718224544177666317857579671398392494738990421742778480874510275496701661767246156082782765447281389173366551964797226777209596403584968660779279643953165474162593368867739334457495539242802990912429373922761158981941812871647584253086806151419918556849286150403796242892769292463889965254699664874725414265944978894889252728525122912669436458328217419950581659522872239871852376728586728655751684959427133823692772366794908442462483779242493189128886251889411534313470401539382033158513483889719447313055276056795067939823844727902968956884967524345381493290261315296287666496242481805847671239741390478482869466932963638542344830287738103143539896567829133212484364913673816749865636383087382823453587906964557547833944595997807832983220825619808184423671794651289928454611977788908397468754205178813569998192456358329423916231178020168996883957635913836767535166954668979954673542118374453857827831233619122494608515696616514397182352539567862121196459366590105598862533422994455583296525122199697530407524276450694820818943817617228824521113612149622768628260296062407288563722958315584317948178189815521589655045964332894639439537927944482367422926168990389962568780179484497254542576867588495345276140803333414817858974395689461799145479167093812641752175862096961957247783574557769221858843142265884839132930491754294432781282279847331798157018464296274313304462656358414465957113901436594895229021517914159428736852634050567929284955663826264987875132308129927829952286999349329551218114522262103535964337447567894713614541545955969086119837433892476969398754733946997612695357714491982859846797677354364588181320555384508113848319624678922473665588154963705540658693239877769268377665855081388836699947279253108457347937255195965964211199303160204827664979829498444071929278334160681033663346747178495613793363798218321368167540342244981815436547611338139858406254409391515954408214648274644760512191852444254898134626749185213035481036753965614828422625623440756941526381981016385011232628191494189328254488913783981716402618796313827250252755618617611590382772864144665786206683503411809942209941924044133174339637608966705364854397409178432148621815472625256510271388937610965576603028994895611857472634894925375729572456722639985930473235932161537989777162714511599197759957747372663080691539816384567643529526372795532698119411458770124931759828641672999753448616792116368167865936661430604323986466614096134878172830669946394368899083243146404784514485883613793790921984155799705335349063197061333941126059791296595258682870537345281626619063701750821754978820727173207125858990824029174013839699982632107851719430388356424521915266875017465393887934182977259849631430964457533750587243487987428881994973535045662026163548141497262651261075772319372695742649818969789584276115245030645987916349435914397671825424718657461740624650212790273273607923893131787757747574531462736998256358192358659991893872182179897815622461886015118084639322633245457180564880788057679085511561885489582047902060524523105491199637372334799247508920208946987782285654548649668222707314691149917270113559521145559320983534971578869540428856104463496315789178566017986711873259296491719941794865857824539855274548134754314667744516789620237154881426388192474127998052282749586242947139122843679220792784402012775275717651428414903524719849198390571522769671921577888553713353704210591235941042483620651134871947518648411596676030416320508421106769507865824530134472783912265931886383802127853638592415868480745512685725619057223729245521462663454775545726295534262866782981774017489861254994343074629884437912677289807777838857989298685467151491262099331791219853563763149132414478465617419840146758784180439227914369426061259498352392309416973879643782237122285179821246356652969880674390637816949156496788381612126427366796252192851426415234687716568142825914401394534458842723838013543860534840925629246771473442402050855999497043421471893922897922111052696398985019789967868113691632591713222016681575287914776955254524677163881988863916153595126167633665143829367320399896235755563859584794288272323182863469484043351992666671256887211625499014375755896097345717136075317593985184563661296380107445869225464393994830329612108076346372151666728991368648333363848126868831201774704311948812571082691864254953926796561124253060525373984023693288311018867521366536776566484654208193669827829966608418191846765494619764905618433759949013622841179863994635562667636468457793779447362721667712578164444116163374572337783021657543325412759059642184954247206114557598466486736153165097257366682425752379867328392542553662866852964679562835326314672910133795696545354069635857909438447418504174107696187069995048822426875935158917367654571412661325873785296547724995789348234696539699411232213136584551147553209882585678308556537319979576347754322816345013982083172719735580481510988863509751265939642035755720698841383925749292297384364892979654945252926915539834566059887051173158357861135924256216843295492024167984981686541079835350884385114386761568545037429942977321246479991857644412583780572260279636717675426436408949264756787339129077214829702926682291199020469994795716751790263457529510349069864456714649734638183842262827395655138415855436562611434063256815783912432529409324241789987896775694246922541821287317246980697166734180273055867050766845545358521064929637361645889970563814174532949989377759246030961590163184323387372773318299271425356875364722289149409374109359945620139864743777521789575682616795469755408988427493145876225153862741647538188631507119528870221172389270349148766610314236828718565295539398989985252777956582689062821615496143753367759863337952887379238448368581953946194626646937403455994374659441818762589675463210621397229654653551238411193540776963237330921921489774108796578178905140699673978867777591249336158966783069175531263313583888562665681025394432231680179592725046847889195890284944101182238076917829221743352024711813419937357459394872656730644238867285652674727638479525528083503712752763414155157063924378598375906440625182384482999786991740617659451020246157786458508851961212497118574266561572365540799832307844229521539838597627319598352112421398137846339177105490946422449732767423368344977535214128552117702738701824904847117719256937129774801786518342961046738161537136562868831912608667903743732772211346655728343127736021572376173065262573172652605822135122429870132821818664748443795279911828465713216054875076946648956635139455121632999141553593616648612274451493466431881148718999704660725642227959992791144577212846308390625076498654321119283171562058484038964593125117448624444199852317474497504452934124498764863881543978138646757629612730667617816136403846163388104889788558554017213572765294387782168778506181219872431442858412505724196929118639917131358314413124407615124882352652565648817516427598364842742165365073643075631375453913526775175450876540158450443331124873625681453158984651859543275188386631162559259658842094789748135117858792926427621958218319999174911855886217251492633937143168619646305479457561736473547544415239559813703341511818446220263565622819948466733890447696423338624233199811319745719046454237779168965131203373327349738620112928341120715350682163829131943161317757389419947640731691633491185965813184315866985594327628395456948182166865832922917875706980495748564213251838444144233143229222293787786522296976523856616218628728467613591591211255723032817827851461285368582560104655952079994231657651279274263038922559697515467055973320345083681229199623326457736354818466634535126633104099938578209191313857436348939079853085335219172881719983446639597939861926675676238113294669279763887177738677493774143765531898814213775433522459156831493244339369529327931589815664395631798645158093183063646461906792774766171892842084579640452881668820867083842196146651963595844496998668622341856841241212907793426752778753301915963912115492378517582693272741218174736014183266196331316772381277101077296674941879945222672970983113385080762179934066759580681450967297584627725881981917816726939299212761733672394835262068731448148496549522316213278943241467301970459236673054689975882962199870572685471253697449826191744313233584359259847886403970369016972017404963954923524787785374621534361281567928119680444155648923154966457860717875526133946650273524731236959980937897846046393782735051172165441458865949558721467093742245327944415929602322574781733869958974848778905418388529822367359822283243707674606683784266537738412786143242834085869851598040855759107763971241137114362872701819231652756752677346624887907451293358476370132342915831157384144127947798115269822981964973541285593748601423803838917819458547967161683139551563877998663995869916168750277167978318438951874276341399334687649377805473678996332726312034839899271970782585841014451530946874741565614356875399784921916899194212404256232086332763593034432774768937589635466144422644336049503926567898411927385460201916848824987665239142435354546575113386598235494079244265717956201264628049491741756469801339865437808221874823212583228148637750883585311086946726831063923774888443147728199628342814177148358636193255229315217634641545362873134674141841744143797681795829681216532064227335721658131914568984604766584937965053615760869870231277472671697914725053326440544686537565193795427251372230587482555496911037614432982843146559753397282129588223786936406335423111422047542364304976772521662594351416642983114717628151174174668026662947665762497816158050528650975468302517507871996011642762518561721730152458317327297231111654835527797777633167322386989840437641352714559222873720805041993650471479607261829561706752773754371969355696544591806995526718532214949816598077618053218048547434894699415531165237259360131690772142627641309762135654382378339622679736895043319199907672676072274982487611236150763495487327198048542957832838786425493528299516851788669579239783528370756559572242572378985686872747803690206228454925738559892824897258124264415086863265611691178696932267486345238091878490782187543872583933883736107335718692885917366960653664883537403737765723428426202015407548418440653262213540979527351914585434611034351874796678542519698835589270999747576242736119736350339155451772999844672725185271714461162272535434994418683811269586768372135044212172117878311833152897813553329653257929548860887086535529404466469318589469291636516695702764976997751046604583258658681947824757236685322653783666189142705769536874551675311751125577945845237345848053748140581877229463148644212346832869455417459768717229118422313354294581843820279351117293879875523396499812169752369318377453805750331819193124189530391013533935273828742950489087251221279132811079166969214175337584663735315345247423649526327369801978386931658973289154463968242417118789298499674820439089513445447438866069169736279215785457868715842475543016356329692863522172637131623196302310865071821348443099514823806176746544134326772640652141568288629717387332195450159070604353975356183952903285836272474694282188283458714826321344203561684586803111851067612778134290295248393249267513215753748041305353141319367970596928266310128852147195113119256149228024634748958651294824792449512430121219162085953035306616591783803262549977559519317025944763587527257492537338594047661979104894984067547811901874737534633239214653362626661656392929626220456963383888501088207546427987518070971042127586775465427319803110531831535159267813898875287856529476264172888180195645634596652695401771837317487462876729739082292969552194966086771815239281595354235061287685352062689745564532693434867453577887953583747988781541752946459234417830477116915476565197444398192295893412469270291569729611863013213359545789409341469213464126499419698279471931214289245150456834693894482832889076311060256763304811713119734788223315288143105319742659401838514627819951892638661196977711333238265027136047444061672221606868148624848469816680232033937995925117292626205294884539289954638187991513898263776566859490307716288473244751391619881080819878876842803363902750808112505660282028112625625726942452836949265456419131343169494965615141951492267570196950137637219459287016999891972849695518373783348322633852646394955671705114141762578773906414765399309550597096429186288829832246752475785245752424794585636343943529209568318515424745864399859052946961152589221516204992225682313840326648195881866051295715508844842499479283671412248674775194753955153165307290553327724450595468344961316130993484143968858836707777279889811782759284986749581120151024233977811081469555333091337941837016583668339199959570614381387252651761331328318149991382289577568416465935572913539151736012169092879224495060514327992855388551434148656696546965709380204286553714159862419568194766183250539522266327436368174149215471993528318356431285434928764769707396958295386596571279404266474793763419317030914361539645966764454991489821801246301727532769785180993214491434824716968881211465627453458366521347209129359179467822518238401021828040813120464669979348826868882328533997668354715589448058275468602111277849827769117449392068923914365564567930775720934726938376841358965750954069163094746564772484573560406133373595314923759048855834537645686273615663703837582271671587529111298541478584781168363820458373202098545856584876194853845366366659607576695784328535868514528696178558242751708793106326553874325816873898243889382710447333183867897486795283455988432672658631479437291570848094744999481238885357135329314396734260569214159650791969894910973092917933249919734651578356119077308046716869921293167978784885726676445743508368635519815755599947947489608168396660339336966972959397955773783355954930877981879983916444136439469732152594569855448549513774377298225481398022666092797191516133674018367981525378503033951457894144788667226160293956291739492336744024122092367278513670754050872760923463941619319443858349536235667556941485307788289945448856856576966020134225404939419244314015963587748651884839524840299754321962337395535442107796595317213753203399137467129573967037975848593832821940542432314441231683244266191546788490529287544048804485881376531897159853555443868430663328688166526254818965814781147310115474878189514138844350125573174913714793187064251689416382629041904639879819397075437490482248127739306997139445855825165237663318487320376477698263583264111393393925937663422736904471882869432661864624227915332739202088627557503299172865934327824895236289642250467837671913923391533876617841425654923396203569652772358935814594652872284542337363654343171895672944116934951335166695222444745581465540118360125166368435259665495140704674402510288580143354919946432524578665169995963937488264446672382476102966984353862732268154404243186549107639229141943168932543566095191360284459824557231683835421923234789058915347275822655779709970747593538469169841645717312382405481658865607164169454983742189988453061855690318177597742509613213690586286135278374660908753239880735310944582377244306282546486765535986524384230664274638269187575818359946017663468111518479564646337389433438028904951103290415758317050994417174884422827266556678790307487414823136336186512847861375054786185245616684832757138762042293562384396158070266517131052348668515766498028629564336875264386687165287847933452165452718895135749379638351784521974263957314584936097416131101746973636286346274457494655717097565167907415202664295536726772621972674550826437218166123893632793364860188815892632948446648791153340156724403233595436352666901265698834103628587597705079301779331177991780269556484841753283942553202860854232222876699012819433977994301070117495594537881664311420133819987289653971208944874470928395142384673864271284771952412776459746619912392163479458857046842345778145837892975387301689861191731523244018531849587769764056659554577082806563174445927276137789151643131684773988796344952484374958745955582540742229115334403424529775151914192634941059519486467596245647691139549271111699527372491719232036336781651995733350267492766211694834988456959763788969118294544167709413541082699365976198799155467066427352101959451217851089495895872350554919127421344443325918629675858544882710452668276055531536492960422951262218367321172782392781995079825099124219681921904126401322582373903931259574555796926325655649941742499238363838376918661884665810561179656978952514813164804596339480932160852730731680682233615130448485262739259529452469589764419934192388767693603956212168119949819749915319551299396342499743309517537211716338944815693853301090904757397260119047422848173759573438536852325615475685311253553968438134968167158012634180149032973322908875839111425419198582797248948029974890419180215631916295819755105356157418736222336368775955806316746242216940951927647821555829531759287877773477426550503425322286883983835158882978767217523340106683643492202383569239292254789523793086555714242589477750661448495066535328286148394957937140845651484929361734118262332618678557958657765570276356526392209028959";
    }
}
