//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_Rollingnotice : ITableOperate
{ private const string TAB_FILE_DATA = "rollingnotice.txt";
 public enum _ID
 {
 INVLAID_INDEX=-1,
ID_CONTENT,
ID_TYPE,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private string m_Content;
 public string Content { get{ return m_Content;}}

private int m_Type;
 public int Type { get{ return m_Type;}}

public bool LoadTable(Hashtable _tab)
 {
 if(!TableManager.ReaderPList(GetInstanceFile(),SerializableTable,_tab))
 {
 throw TableException.ErrorReader("Load File{0} Fail!!!",GetInstanceFile());
 }
 return true;
 }
 public void SerializableTable(ArrayList valuesList,string skey,Hashtable _hash)
 {
 if (string.IsNullOrEmpty(skey))
 {
 throw TableException.ErrorReader("Read File{0} as key is Empty Fail!!!", GetInstanceFile());
 }

 if ((int)_ID.MAX_RECORD!=valuesList.Count)
 {
 throw TableException.ErrorReader("Load {0} error as CodeSize:{1} not Equal DataSize:{2}", GetInstanceFile(),_ID.MAX_RECORD,valuesList.Count);
 }
 Int32 nKey = Convert.ToInt32(skey);
 Tab_Rollingnotice _values = new Tab_Rollingnotice();
 _values.m_Content =  valuesList[(int)_ID.ID_CONTENT] as string;
_values.m_Type =  Convert.ToInt32(valuesList[(int)_ID.ID_TYPE] as string);

 _hash.Add(nKey,_values); }


}
}

