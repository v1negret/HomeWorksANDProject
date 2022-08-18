
using FileManagement;

DirectoryClass.CreateDirectory(@"C:\otus\TestDir1");
DirectoryClass.CreateDirectory(@"C:\otus\TestDir2");

for(int i = 1; i <= 10; i++)
{

    string temp = @"C:\otus\TestDir1\File";
    var createTime = DateTime.Now;
    temp += (i + ".txt");

    FileClass.CreateFile(temp);
    var fileName = FileClass.GetNameByPath(temp);
    FileClass.WriteToFile(temp, (fileName + " " + createTime));

}
for (int i = 1; i <= 10; i++)
{

    string temp = @"C:\otus\TestDir2\File";
    temp += (i + ".txt");
    var createTime = DateTime.Now;

    FileClass.CreateFile(temp);
    var fileName = FileClass.GetNameByPath(temp);
    FileClass.WriteToFile(temp, (fileName + " " + createTime));

}