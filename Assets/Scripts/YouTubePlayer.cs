using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouTubePlayer : MonoBehaviour {

    public UniWebView uniWebView;
    private static readonly string videoFile = "Ccj_H__4KGQ";

    // Use this for initialization
    void Start () {
        // USE HTML WEBVIEW FOR VIDEO:                    
        Debug.Log("YOUTUBE PLAYER: start.");

        uniWebView = GetComponent<UniWebView>();

        uniWebView.OnPageStarted += (view, url) => {
            Debug.Log("YOUTUBE PLAYER: OnPageStarted with url: " + url);
        };
        uniWebView.OnPageFinished += (view, statusCode, url) => {
            Debug.Log("YOUTUBE PLAYER: OnPageFinished with status code: " + statusCode);
        };
        uniWebView.OnPageErrorReceived += (UniWebView webView, int errorCode, string errorMessage) => {
            Debug.Log("YOUTUBE PLAYER: OnPageErrorReceived errCode: " + errorCode
                      + "\n\terrMessage: " + errorMessage);
        };

        UniWebViewLogger.Instance.LogLevel = UniWebViewLogger.Level.Verbose;



        //float headerHeight = LayoutConfig.Units2Pixels(LayoutConfig.HeaderHeightUnits); // + 30;
        //float footerHeight = LayoutConfig.Units2Pixels(LayoutConfig.FooterHeightUnits); // + 30;
        //uniWebView.Frame =
        //    new Rect(
        //        0, headerHeight,
        //        Device.width, Device.height - (headerHeight + footerHeight)
        //    );
        //Debug.Log("YOUTUBE PLAYER: frame set.");

        string videoHtml = string.Format(YoutubeHTMLFormatString, videoFile);
        uniWebView.LoadHTMLString(videoHtml, "https://www.youtube.com/");
        Debug.Log("YOUTUBE PLAYER: htmlString loaded.");
        uniWebView.SetShowSpinnerWhileLoading(true);
        Debug.Log("YOUTUBE PLAYER: spinner set.");
        uniWebView.UpdateFrame();
        uniWebView.Show(true);
        uniWebView.UpdateFrame();
        Debug.Log("YOUTUBE PLAYER: after show()");

    }

    private static string YoutubeHTMLFormatString =
       @"<html>
                <head></head>
                <body style=""margin:0\"">
                    <iframe width = ""100%"" height=""100%"" 
                        src=""https://www.youtube.com/embed/{0}"" frameborder=""0"" 
                        allow=""autoplay; encrypted-media"" allowfullscreen>
                    </iframe>
                </body>
            </html>";
}
