using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.AddressableAssets;
using System.IO;
using HeurekaGames;

public class MenuScript : Singleton<MenuScript>
{
    public Button start, playerOneVsOne;
    public InputField player1, player2;
    public GameObject OneVsOnePanel, levelSelectPanel, loadingPanel, MainMenuPanel, ballSelectionPanel;

    public GameObject[] Levels;

    public Image img;
    public Text CoinsText, CoinsText1, CoinsText2, CoinsText3;

    public GameObject shopUIPanel, coinspanel, ballpanel, IAPPanel;

    public Button coinsBtn, IAPBtn;

    bool isballSElection;

    public string num;

    public GameObject MainCamera, ballsPrice;

    public GameObject[] balls;
    public int[] price;

    GameObject pricecollider;

    public GameObject buybtn, Selectbtn;

    public int[] isball;

    public GameObject[] hundradPinsBtn;

    public GameObject RewardMenu, ballcollider, nointernetpanel;

    public GameObject audioon, audiooff;

    public Text ballsize, twopins, ghostbal, nogutter, twinball;


    public Text CoinsOnMain;

    public GameObject gdprPanel, Agreebtn, GamePanel, gamepanelBtn;

    public int CheckRemoteLevel, coin1_price, coin2_price, coin3_price, coin4_price, coin5_price;

    public GameObject ads_removebtn, LevelsUnlock, notEnoughCoins_pael;

    public Text Coin1, Coin2, Coin3, Coin4, Coin5;


    //    void OnGUI()
    //    {
    //        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 5, Screen.width / 2, Screen.height / 10), "Start"))
    //        {
    //            Application.LoadLevel("Scene_1");
    //        }
    //        if (GUI.Button(new Rect(Screen.width / 20f, Screen.height / 10, Screen.width / 2, Screen.height / 10), "Options"))
    //        {
    //            Application.LoadLevel("Options");
    //        }
    //
    //        if (GUI.Button(new Rect(Screen.width / 40f, Screen.height / 50f, Screen.width / 2, Screen.height / 10f), "Quit"))
    //        {
    //            Application.Quit();
    //        }
    //    }

    void Awake()
    {
    }


    void Start()
    {
//				PlayerPrefs.DeleteAll ();

        Time.timeScale = 1;
        //		PlayerPrefs.SetInt ("Levels",10);

        GlobalGameHandler.selectedballs = 0;
        pricecollider = ballsPrice.transform.parent.GetChild(0).gameObject;

        //		GlobalGameHandler.ball_number=	PlayerPrefs.GetInt ("balls");
        //		GlobalGameHandler.ball_number = 2;
        GlobalGameHandler.hundradPins = false;
        PlayerPrefs.SetInt("ballsselected" + 0, 1);
        GlobalGameHandler.NoGutter = PlayerPrefs.GetInt("NoGutter");
        GlobalGameHandler.ballsize_Double = PlayerPrefs.GetInt("BallSizeUp");
        GlobalGameHandler.two_pins = PlayerPrefs.GetInt("twoPins");
        GlobalGameHandler.Ghoost_Ball = PlayerPrefs.GetInt("GhostBall");
        GlobalGameHandler.two_balls = PlayerPrefs.GetInt("TwoBalls");
        GlobalGameHandler.coins = PlayerPrefs.GetInt("Coins");

        twinball.text = GlobalGameHandler.two_balls.ToString();
        ghostbal.text = GlobalGameHandler.Ghoost_Ball.ToString();
        twopins.text = GlobalGameHandler.two_pins.ToString();
        ballsize.text = GlobalGameHandler.ballsize_Double.ToString();
        nogutter.text = GlobalGameHandler.NoGutter.ToString();


        //		GlobalGameHandler.NoGutter = 3;
        //		GlobalGameHandler.ballsize_Double = 3;
        //		GlobalGameHandler.two_pins = 3;
        //		GlobalGameHandler.Ghoost_Ball = 3;
        //		GlobalGameHandler.two_balls = 3;


        GlobalGameHandler.OneVsOne = false;


        for (int i = 0; i < 5; i++)
        {
            isball[i] = PlayerPrefs.GetInt("ballsselected" + i);
        }

        notEnoughCoins_pael.SetActive(false);
        //		MainCamera.GetComponent<Animator> ().SetBool ("isball",false);
        MainCamera.transform.GetChild(0).gameObject.SetActive(false);
        GlobalGameHandler.issound = true;
        nointernetpanel.SetActive(false);
        ballsPrice.SetActive(false);
        isballSElection = false;
        shopUIPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        loadingPanel.SetActive(false);
        OneVsOnePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        ballSelectionPanel.SetActive(false);
        GlobalGameHandler.isOvO = false;
        start.interactable = true;

        CoinsText.text = GlobalGameHandler.coins.ToString();
        CoinsText1.text = GlobalGameHandler.coins.ToString();
        CoinsText2.text = GlobalGameHandler.coins.ToString();

        //		PlayerPrefs.DeleteAll ();
        int levels = PlayerPrefs.GetInt("Levels");
        int b = PlayerPrefs.GetInt("balls");
        //		Debug.Log ("Level number  " + a);
        //		a = 9;
        b = GlobalGameHandler.ball_number;
        print("levels" + levels);

//		


        levellocks(levels);
        balls_Lock(b);

        hundradlevelson();

        if (GlobalGameHandler.isrewardMenu)
        {
            RewardMenu.SetActive(false);
        }

        int c = PlayerPrefs.GetInt("Coins");
        CoinsOnMain.text = c.ToString();

        gamepanelBtn.SetActive(false);

        if (GlobalGameHandler.nextlevel)
        {
            onPlaybutton();

            //addddd
            //			AdsScript.ShowTopLeftBanner ();
        }


        //		foreach(GameObject obj in l)

        //		AdsScript.ShowSmartBanner ();
        //		AdsScript.RemoveTopLeftBanner ();
        //addddd
        //		AdsScript.RemoveTopLeftBanner ();
        if (levels >= 50)
        {
            LevelsUnlock.SetActive(false);
        }

        if (PlayerPrefs.GetInt("RemoveAds") == 1)
        {
            ads_removebtn.GetComponent<Button>().interactable = false;
        }
    }

    public void Remot_settings()
    {
        int levels = PlayerPrefs.GetInt("Levels");

        if (CheckRemoteLevel > 0)
        {
            print("check remot level " + CheckRemoteLevel);
            if (levels < CheckRemoteLevel)
            {
                levels = CheckRemoteLevel - 1;
                print("check remot level " + CheckRemoteLevel);
            }
        }

        print("Coin1 Price " + coin1_price);

        if (coin1_price > 300 || coin1_price < 300)
        {
            print("Coin1 Price " + coin1_price);

            Coin1.text = coin1_price.ToString();
            print("Coin1 Price " + coin1_price);
        }

        if (coin2_price > 500 || coin2_price < 500)
        {
            print("Coin2 Price " + coin2_price);

            Coin2.text = coin2_price.ToString();
            print("Coin2 Price " + coin2_price);
        }

        if (coin3_price > 1000 || coin3_price < 1000)
        {
            print("Coin3 Price " + coin3_price);

            Coin3.text = coin3_price.ToString();
            print("Coin3 Price  " + coin3_price);
        }

        if (coin4_price > 3050 || coin4_price < 3050)
        {
            print("Coin4 Price " + coin4_price);

            Coin4.text = coin4_price.ToString();
            print("Coin4 Price  " + coin4_price);
        }

        if (coin5_price > 5100 || coin5_price < 5100)
        {
            print("Coin5 Price  " + coin5_price);

            Coin5.text = coin5_price.ToString();
            print("Coin5 Price  " + coin5_price);
        }
    }


    public void hundradlevelson()
    {
        foreach (GameObject obj in hundradPinsBtn)
        {
            obj.SetActive(false);
        }

        int a = PlayerPrefs.GetInt("Levels");
        int hund = PlayerPrefs.GetInt("hund");
        //		print ("hund"+hund);
        if (a == 9)
        {
            //			print ("hund" + hund);
            hundradPinsBtn[hund].SetActive(true);
        }
        else if (a == 19)
            hundradPinsBtn[hund].SetActive(true);
        else if (a == 29)
            hundradPinsBtn[hund].SetActive(true);

        else if (a == 39)
            hundradPinsBtn[hund].SetActive(true);
        else if (a == 49)
            hundradPinsBtn[hund].SetActive(true);
    }

    public void balls_Lock(int number)
    {
        for (int i = 0; i < balls.Length; i++)
        {
            if (isball[i] == 1)
            {
                balls[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
                pricecollider.GetComponent<ballprice>().price[i].gameObject.SetActive(false);
            }
            else if (isball[i] == 0)
            {
                balls[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
                pricecollider.GetComponent<ballprice>().price[i].gameObject.SetActive(true);
            }
        }

        //		for (int i = 0; i < number; i++) {
        ////			balls [i].gameObject.GetComponent<BoxCollider> ().enabled = true;
        //			balls [i].gameObject.transform.GetChild (0).gameObject.SetActive (false);	
        //			pricecollider.GetComponent<ballprice> ().price [i].gameObject.SetActive (false);
        //		}
    }

    public void onBallsetectbtn()
    {
        GlobalGameHandler.ball_number = GlobalGameHandler.ball_open;


        backinLEvelSelection();

        //		print (GlobalGameHandler.ball_open);
        int c = PlayerPrefs.GetInt("Coins");

        CoinsText.text = c.ToString();
        CoinsText1.text = c.ToString();
        CoinsText2.text = c.ToString();
        //addddd
        //		AdsScript.ShowTopLeftBanner ();
        StartCoroutine(remote_seting_Cor());
    }

    public void hundradspinclick()
    {
        GlobalGameHandler.hundradPins = true;
        StartCoroutine(loadingCorutine());
    }

    public void onBallbuybtn()
    {
        int coin = PlayerPrefs.GetInt("Coins");


        if (coin >= price[GlobalGameHandler.ball_open])
        {
            PlayerPrefs.SetInt("Coins", coin - price[GlobalGameHandler.ball_open]);


            isball[GlobalGameHandler.ball_open] = 1;
            PlayerPrefs.SetInt("ballsselected" + GlobalGameHandler.ball_open, isball[GlobalGameHandler.ball_open]);

            balls[GlobalGameHandler.ball_open].gameObject.transform.GetChild(0).gameObject.SetActive(false);
            ballcollider.GetComponent<ballprice>().price[GlobalGameHandler.ball_open].gameObject.SetActive(false);
            GlobalGameHandler.coins = PlayerPrefs.GetInt("Coins");
            Selectbtn.SetActive(true);
            CoinsText.text = GlobalGameHandler.coins.ToString();
            CoinsText1.text = GlobalGameHandler.coins.ToString();
            CoinsText2.text = GlobalGameHandler.coins.ToString();
            CoinsText3.text = PlayerPrefs.GetInt("Coins").ToString();
            //			print ("vall"+GlobalGameHandler.ball_open);
        }


        //		print (GlobalGameHandler.ball_open);
        //addddd
        //		AdsScript.ShowTopLeftBanner ();
    }

    public void AddCoin(int coin)
    {
        int c = PlayerPrefs.GetInt("Coins");

        GlobalGameHandler.coins = c + coin;
        CoinsText.text = GlobalGameHandler.coins.ToString();
        CoinsText1.text = GlobalGameHandler.coins.ToString();
        CoinsText2.text = GlobalGameHandler.coins.ToString();
        CoinsText3.text = GlobalGameHandler.coins.ToString();

        PlayerPrefs.SetInt("Coins", GlobalGameHandler.coins);
    }

    public void OnballSelection()
    {
        ballsPrice.SetActive(true);
        ballSelectionPanel.SetActive(true);
        shopUIPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        loadingPanel.SetActive(false);
        OneVsOnePanel.SetActive(false);
        //		MainCamera.GetComponent<Animator> ().SetBool ("isball",true);
        MainCamera.transform.GetChild(0).gameObject.SetActive(true);
        //addddd
        //		AdsScript.ShowTopLeftBanner ();
    }

    public void levellocks(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Levels[i].gameObject.GetComponent<Button>().interactable = true;

            Levels[i].gameObject.GetComponent<Image>().color = new Color(255, 255, 255);

            //			Levels [i].gameObject.transform.GetChild (0).gameObject.SetActive (false);
        }
    }

    public void onPlaybutton()
    {
        ballSelectionPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        //		loadingPanel.SetActive (false);
        levelSelectPanel.SetActive(true);
        Remot_settings();
        print(PlayerPrefs.GetInt("Levels"));
        //addddd
        //		AdsScript.ShowTopLeftBanner ();
    }

    IEnumerator loadingCorutine()
    {
        levelSelectPanel.SetActive(false);
        loadingPanel.SetActive(true);


        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scene_1");

        //		yield return new WaitForSeconds (0.1f);
    }

    public void onlevelSelbtn(int i)
    {
        //		int i = System.Convert.ToInt32 (name);
        Time.timeScale = 1;
        GlobalGameHandler.Level_number = i - 1;

        isballSElection = true;

        StartCoroutine(loadingCorutine());
    }


    //	public void LoadImage(){
    //
    //
    //		NativeGallery.GetImageFromGallery (( path) => {
    //			Debug.Log ("Image path: " + path);
    //			if (path != null) {
    //				// Create Texture from selected image
    //				Texture2D texture = NativeGallery.LoadImageAtPath (path, 1024); // image will be downscaled if its width or height is larger than 1024px
    //				if (texture == null) {
    //					player1.text="nothing geted";
    //
    //					Debug.Log ("Couldn't load texture from " + path);
    //					return;
    //				}
    //				WriteTextureToPlayerPrefs("player1",texture);
    //
    //				Debug.Log ("Couldn't load texture from " + path);
    ////				Rect rect= Rect(0, 0, texture.width, texture.height);
    //		
    ////				Sprite.Create(texture,Rect(0, 0, texture.width, texture.height)	, new Vector2(0.5f, 0.5f));
    ////				img.GetComponent<Image> ().overrideSprite = texture;
    //
    //
    //			
    //				// Use 'texture' here
    //				// ...
    //			}
    //		});
    //
    //	
    //
    //
    //		Texture2D tex	=ReadTextureFromPlayerPrefs ("player1");
    //
    //	
    //		img.sprite = Sprite.Create (tex, new Rect (0, 0, 128, 128), new Vector2 ());//set the
    //
    //
    //		player1.text=img.sprite.name;
    ////		img.GetComponent<Image> ().overrideSprite = texture;
    //
    //	}

    //	void HandleMediaPickCallback (string path)
    //	{
    //		
    //	}

    public void OnOneVsOnePlay()
    {
        playerOneVsOne.interactable = false;
        string a = player1.text.ToString();
        string b = player2.text.ToString();

        PlayerPrefs.SetString("Player1", a);
        PlayerPrefs.SetString("Player2", b);

        //		print (a);
        //		print (b);

        GlobalGameHandler.isOvO = true;
        GlobalGameHandler.OneVsOne = true;
        OneVsOnePanel.SetActive(false);

        StartCoroutine(loadingCorutine());

        //		SceneManager.LoadScene("Scene_1");
    }

    public void OnOneVsOne()
    {
        OneVsOnePanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        //addddd
        //		AdsScript.ShowTopLeftBanner ();
    }

    public void OnQuit()
    {
        Application.Quit();
    }


    public static void WriteTextureToPlayerPrefs(string tag, Texture2D tex)
    {
        // if texture is png otherwise you can use tex.EncodeToJPG().
        byte[] texByte = tex.EncodeToPNG();

        // convert byte array to base64 string
        string base64Tex = System.Convert.ToBase64String(texByte);

        // write string to playerpref
        PlayerPrefs.SetString(tag, base64Tex);
        PlayerPrefs.Save();
    }

    public static Texture2D ReadTextureFromPlayerPrefs(string tag)
    {
        // load string from playerpref
        string base64Tex = PlayerPrefs.GetString(tag, null);

        if (!string.IsNullOrEmpty(base64Tex))
        {
            // convert it to byte array
            byte[] texByte = System.Convert.FromBase64String(base64Tex);
            Texture2D tex = new Texture2D(2, 2);

            //load texture from byte array
            if (tex.LoadImage(texByte))
            {
                return tex;
            }
        }

        return null;
    }


    public void backinOneVsOne()
    {
        //		MainCamera.GetComponent<Animator> ().SetBool ("isball",false);
        MainCamera.transform.GetChild(0).gameObject.SetActive(true);
        OneVsOnePanel.SetActive(false);
        shopUIPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        loadingPanel.SetActive(false);
        OneVsOnePanel.SetActive(false);
        ballSelectionPanel.SetActive(false);
        MainMenuPanel.SetActive(true);

        ballsPrice.SetActive(false);

        int c = PlayerPrefs.GetInt("Coins");
        CoinsOnMain.text = c.ToString();
        //addddd
        //		AdsScript.RemoveTopLeftBanner ();
    }

    public void backinLEvelSelection()
    {
        //		MainCamera.GetComponent<Animator> ().SetBool ("isball",false);
        MainCamera.transform.GetChild(0).gameObject.SetActive(true);
        shopUIPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        loadingPanel.SetActive(false);
        OneVsOnePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        //		print ("back");
        ballSelectionPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        nointernetpanel.SetActive(false);
        ballsPrice.SetActive(false);

        //		AdsScript.RemoveTopLeftBanner ();
    }

    public void OnShareClick()

    {
        StartCoroutine(TakeSSAndShare());
    }

    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();


        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);


        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();
    }


    public void OnShopClick()
    {
        IAPBtn.interactable = true;
        coinsBtn.interactable = false;
        coinspanel.SetActive(true);
        IAPPanel.SetActive(false);
        shopUIPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
        loadingPanel.SetActive(false);
        OneVsOnePanel.SetActive(false);
        ballSelectionPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        int c = PlayerPrefs.GetInt("Coins");

        CoinsText.text = c.ToString();
        CoinsText1.text = c.ToString();
        CoinsText2.text = c.ToString();
        CoinsText3.text = PlayerPrefs.GetInt("Coins").ToString();


        Remot_settings();
        //		AdsScript.ShowTopLeftBanner ();
    }


    public void coinspanelCLick()
    {
        coinsBtn.interactable = false;
        IAPBtn.interactable = true;
        coinspanel.SetActive(true);
        ballpanel.SetActive(false);
        IAPPanel.SetActive(false);
    }

    public void bALLpanelCLick()
    {
        coinspanel.SetActive(false);
        ballpanel.SetActive(true);
        IAPPanel.SetActive(false);
    }

    public void IAPpanelCLick()
    {
        coinsBtn.interactable = true;
        IAPBtn.interactable = false;
        coinspanel.SetActive(false);
        ballpanel.SetActive(false);
        IAPPanel.SetActive(true);
    }


    //	PlayerPrefs.SetInt ("ballsselected" + 0, 1);
    //	GlobalGameHandler.NoGutter = PlayerPrefs.GetInt ("NoGutter");
    //	GlobalGameHandler.ballsize_Double = PlayerPrefs.GetInt ("BallSizeUp");
    //	GlobalGameHandler.two_pins = PlayerPrefs.GetInt ("twoPins");
    //	GlobalGameHandler.Ghoost_Ball = PlayerPrefs.GetInt ("GhostBall");
    //	GlobalGameHandler.two_balls = PlayerPrefs.GetInt ("TwoBalls");
    //	GlobalGameHandler.coins = PlayerPrefs.GetInt ("Coins");
    public void sizeUpBall()
    {
        int b = PlayerPrefs.GetInt("Coins");
        if (b >= 24000)
        {
            int a = PlayerPrefs.GetInt("BallSizeUp");
            PlayerPrefs.SetInt("BallSizeUp", a + 3);

            GlobalGameHandler.ballsize_Double = PlayerPrefs.GetInt("BallSizeUp");

            ballsize.text = GlobalGameHandler.ballsize_Double.ToString();
            PlayerPrefs.SetInt("Coins", b - 24000);


            int c = PlayerPrefs.GetInt("Coins");

            CoinsText.text = c.ToString();
            CoinsText1.text = c.ToString();
            CoinsText2.text = c.ToString();
            CoinsText3.text = PlayerPrefs.GetInt("Coins").ToString();
        }
    }


    public void twinBall()
    {
        int b = PlayerPrefs.GetInt("Coins");
        if (b >= 48000)
        {
            int a = PlayerPrefs.GetInt("TwoBalls");
            PlayerPrefs.SetInt("TwoBalls", a + 3);

            PlayerPrefs.SetInt("Coins", b - 48000);


            int c = PlayerPrefs.GetInt("Coins");

            CoinsText.text = c.ToString();
            CoinsText1.text = c.ToString();
            CoinsText2.text = c.ToString();
            CoinsText3.text = PlayerPrefs.GetInt("Coins").ToString();
            GlobalGameHandler.two_balls = PlayerPrefs.GetInt("TwoBalls");

            twinball.text = GlobalGameHandler.two_balls.ToString();
        }
    }


    public void twinPinPoints()
    {
        int b = PlayerPrefs.GetInt("Coins");
        if (b >= 42000)
        {
            int a = PlayerPrefs.GetInt("twoPins");
            PlayerPrefs.SetInt("twoPins", a + 3);

            PlayerPrefs.SetInt("Coins", b - 42000);

            int c = PlayerPrefs.GetInt("Coins");

            CoinsText.text = c.ToString();
            CoinsText1.text = c.ToString();
            CoinsText2.text = c.ToString();
            CoinsText3.text = PlayerPrefs.GetInt("Coins").ToString();


            GlobalGameHandler.two_pins = PlayerPrefs.GetInt("twoPins");
            twopins.text = GlobalGameHandler.two_pins.ToString();
        }
    }

    public void GhostBall()
    {
        int b = PlayerPrefs.GetInt("Coins");
        if (b >= 54000)
        {
            int a = PlayerPrefs.GetInt("GhostBall");
            PlayerPrefs.SetInt("GhostBall", a + 3);

            PlayerPrefs.SetInt("Coins", b - 54000);


            int c = PlayerPrefs.GetInt("Coins");

            CoinsText.text = c.ToString();
            CoinsText1.text = c.ToString();
            CoinsText2.text = c.ToString();
            CoinsText3.text = PlayerPrefs.GetInt("Coins").ToString();
            GlobalGameHandler.Ghoost_Ball = PlayerPrefs.GetInt("GhostBall");


            ghostbal.text = GlobalGameHandler.Ghoost_Ball.ToString();
        }
    }


    public void NoGutter()
    {
        int b = PlayerPrefs.GetInt("Coins");
        if (b >= 30000)
        {
            int a = PlayerPrefs.GetInt("NoGutter");
            PlayerPrefs.SetInt("NoGutter", a + 3);

            PlayerPrefs.SetInt("Coins", b - 30000);


            int c = PlayerPrefs.GetInt("Coins");

            CoinsText.text = c.ToString();
            CoinsText1.text = c.ToString();
            CoinsText2.text = c.ToString();
            CoinsText3.text = PlayerPrefs.GetInt("Coins").ToString();

            GlobalGameHandler.NoGutter = PlayerPrefs.GetInt("NoGutter");

            nogutter.text = GlobalGameHandler.NoGutter.ToString();
        }
    }


    public void OnAudioon()
    {
        GlobalGameHandler.issound = true;
        //		print ("is Audio "+GlobalGameHandler.issound);
        AudioListener.volume = 1;
        audioon.SetActive(false);
        audiooff.SetActive(true);
    }

    public void OnAudiooff()
    {
        GlobalGameHandler.issound = false;
        //		print ("is Audio "+GlobalGameHandler.issound);
        AudioListener.volume = 0;
        audioon.SetActive(true);
        audiooff.SetActive(false);
    }

    public void OnTermsAndCondionClick()
    {
        Application.OpenURL("https://mentorgamestudio.wordpress.com/2018/10/22/mentor-game-studio/");
    }

    public void OnAgreeBtnClick()
    {
        PlayerPrefs.SetInt("gdpr", 1);
        gdprPanel.SetActive(false);
    }


    public void OnTermsAndCondiotnCheckBox(bool ischecked)
    {
        //		print (ischecked);

        Agreebtn.GetComponent<Button>().interactable = ischecked;
    }

    public void OnGamePanelClick()
    {
        GamePanel.GetComponent<Animator>().SetBool("pm", true);
        gamepanelBtn.SetActive(true);
    }

    public void OnGamePanelOffCLick()
    {
        print("f");
        GamePanel.GetComponent<Animator>().SetBool("pm", false);
        print("f");
        gamepanelBtn.SetActive(false);
        print("f");
    }


    public void Levels_Unlock()
    {
        int a = PlayerPrefs.GetInt("Coins");
        if (a >= 200000)
        {
            PlayerPrefs.SetInt("Levels", 50);
            LevelsUnlock.SetActive(false);
            PlayerPrefs.SetInt("Coins", a - 200000);

            levellocks(50);
            CoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
            CoinsText1.text = PlayerPrefs.GetInt("Coins").ToString();
            CoinsText2.text = PlayerPrefs.GetInt("Coins").ToString();
            CoinsText3.text = PlayerPrefs.GetInt("Coins").ToString();
        }
    }

    public void Ads_remove()
    {
        int a = PlayerPrefs.GetInt("Coins");
        if (a >= 100000)
        {
            ads_removebtn.GetComponent<Button>().interactable = false;
            PlayerPrefs.SetInt("Coins", a - 100000);
            CoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
            CoinsText1.text = PlayerPrefs.GetInt("Coins").ToString();
            CoinsText2.text = PlayerPrefs.GetInt("Coins").ToString();
            CoinsText3.text = PlayerPrefs.GetInt("Coins").ToString();
            PlayerPrefs.SetInt("RemoveAds", 1);
        }
        else
        {
            StartCoroutine(notenoght_coinsss());
        }
    }

    IEnumerator notenoght_coinsss()
    {
        notEnoughCoins_pael.SetActive(true);
        yield return new WaitForSeconds(2f);
        notEnoughCoins_pael.SetActive(false);
    }

    IEnumerator remote_seting_Cor()
    {
        yield return new WaitForSeconds(2f);
        Remot_settings();
    }
}