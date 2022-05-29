using System;
using System.Text;
using System.IO;
namespace Kaizen
{
  class Program
  {
    static string ConvertToBase64String(string code)
    {  
      var codeTextBytes = Encoding.UTF8.GetBytes(code);
      return System.Convert.ToBase64String(codeTextBytes);
    }

    static bool generate_code(string[] plain)
    {      
      string[] code = new string[8];
      string file_path=@"C:\Users\MSI PC\Desktop\generated_code.rtf";
          
      FileStream fs = new FileStream(file_path, FileMode.OpenOrCreate, FileAccess.Write);
            
      StreamWriter sw = new StreamWriter(fs);
        
      for(int k=0;k<1000;k++){
        for(int i=0;i<8;i++){
          Random rnd = new Random(); 
          int random=rnd.Next(0, plain.Length);
          code[i]=plain[random];
        }
        string generated_code = string.Join("", code);
        bool checked_code=CheckCode(code,plain);

        if(checked_code==true){
          string code_base64=ConvertToBase64String(generated_code);
          Console.WriteLine("generated kod: "+code_base64);
          sw.WriteLine(code_base64);    
        }
           
            
      }
      sw.Close();
      fs.Close();
            
      return true;
          
    }
    static void Main(string[] args)
    {
      string[] character = new string[23];     
      character[0] = "A";
      character[1] = "C";
      character[2] = "D";
      character[3] = "E";
      character[4] = "F";
      character[5] = "G";
      character[6] = "H";
      character[7] = "K";
      character[8] = "L";
      character[9] = "M";
      character[10] = "N";
      character[11] = "P";
      character[12] = "R";
      character[13] = "T";
      character[14] = "X";
      character[15] = "Y";
      character[16] = "Z";
      character[17] = "2";
      character[18] = "3";
      character[19] = "4";
      character[20] = "5";
      character[21] = "7";
      character[22] = "9";

      generate_code(character);
    }

    static bool CheckCode(string[] code,string[] plain)
    {
      int count=0;
      string plain_set = string.Join("", plain);
        
      bool check=true;

      while(check==true){

        for(int j=0;j<8;j++){
          check=plain_set.Contains(code[j]);
          count=count+1;
        }
        if(count==8){
          break;
        }
      }
           
      return check;
    }   
  }
}

