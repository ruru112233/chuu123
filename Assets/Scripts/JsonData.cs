using System;
using System.IO;
using UnityEngine;

public class JsonData
{
    /// <summary>
    /// �p�X���擾�@���@�Z�[�u�t�@�C�����L�^
    /// </summary>
    private static string getFilePath()
    {
        return Application.persistentDataPath + "VolumeSaveData" + ".json";
    }

    /// <summary>
    /// �������݋@�\
    /// </summary>

    public static void Save(Data data)
    {
        // �V���A���C�Y���s
        string jsonSerializedData = JsonUtility.ToJson(data);
        Debug.Log(jsonSerializedData);

        // �t�@�C������ď�������
        using (var sw = new StreamWriter(getFilePath(), false))
        {
            try
            {
                // �t�@�C���ɏ�������
                sw.Write(jsonSerializedData);
            }
            catch (Exception e)// ���s�������̏���
            {
                Debug.Log(e);
            }
        }
    }

    /// <summary>
    /// �ǂݍ��݋@�\
    /// </summary>

    public static Data Load()
    {
        Data jsonDeserializedData = new Data();

        try
        {
            // �t�@�C����ǂݍ���
            using (FileStream fs = new FileStream(getFilePath(), FileMode.Open))
            using (StreamReader st = new StreamReader(fs))
            {
                string result = st.ReadToEnd();
                Debug.Log(result);

                // �ǂݍ���json���\���̂ɓ����
                jsonDeserializedData = JsonUtility.FromJson<Data>(result);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        // �f�V���A���C�Y�����\���̂�Ԃ�
        return jsonDeserializedData;
    }
}
