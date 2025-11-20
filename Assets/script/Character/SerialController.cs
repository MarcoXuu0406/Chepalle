using UnityEngine;
using System.IO.Ports;

public class SerialController : MonoBehaviour
{
    SerialPort serial = new SerialPort("COM3", 9600);

    public static string lastCommand = "";

    void Start()
    {
        serial.ReadTimeout = 25;

        try
        {
            serial.Open();
            Debug.Log("Seriale Aperta!");
        }
        catch
        {
            Debug.LogError("Errore apertura porta seriale!");
        }
    }

    void Update()
    {
        if (serial.IsOpen)
        {
            try
            {
                string data = serial.ReadExisting();

                if (!string.IsNullOrEmpty(data))
                {
                    // Prende l’ultimo carattere inviato
                    lastCommand = data[data.Length - 1].ToString();
                }
            }
            catch { }
        }
    }
}
