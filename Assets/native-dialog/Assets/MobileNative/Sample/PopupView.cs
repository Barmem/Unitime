using UnityEngine;
using System.Collections;
using pingak9;
using UnityEngine.UI;
using System;
using System.Globalization;

public class PopupView : MonoBehaviour
{
    public Text datetimetxt;
    public Text unixtxt;
    public DateTime date1;
    public DateTime time;
    public DateTime datet = System.DateTime.Now;
    public void DebugLogdate(DateTime log)
    {
        datet = log;
        datetimetxt.text = datet.ToString();
        time = datet;
        unixtxt.text = ((DateTimeOffset)datet).ToUnixTimeSeconds().ToString();
        Debug.Log(log);
    }
    public void DebugLogtime(DateTime log)
    {
        TimeSpan ts = new TimeSpan(log.Hour, log.Minute, 0);
        datet = datet.Date + ts; 
        datetimetxt.text =  datet.ToString();
        unixtxt.text = ((DateTimeOffset)datet).ToUnixTimeSeconds().ToString();
        Debug.Log(log);
    }


    public void OnDatePicker()
    {

        NativeDialog.OpenDatePicker(datet.Year, datet.Month, datet.Day, 
            (DateTime _date) =>
            {
                DebugLogdate(_date);
            }
            ,
            (DateTime _date) =>
            {
                DebugLogdate(_date);
            }
            );        
    }
    public void OnTimePicker()
    {
        NativeDialog.OpenTimePicker(
            (DateTime _time) =>
            {
                DebugLogtime(_time);
            }
            ,
            (DateTime _time) =>
            {
                DebugLogtime(_time);
            }
            );
    }
    public void CopyToClipboard(){
        GUIUtility.systemCopyBuffer = "<t:" + ((DateTimeOffset)datet).ToUnixTimeSeconds().ToString() + ">";
    }
    public void CopyRelativeToClipboard(){
        GUIUtility.systemCopyBuffer = "<t:" + ((DateTimeOffset)datet).ToUnixTimeSeconds().ToString() + ":R>";
    }
}