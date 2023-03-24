# Tugas Besar 1 IF2211 Strategi Algoritma
> Pengaplikasian Algoritma BFS dan DFS dalam Menyelesaikan Persoalan Maze Treasure Hunt


## Table of Contents
* [About the program](#about-the-program)
* [Requirements](#requirements)
* [Build Program](#build-program)
* [Run Program](#run-program)
* [Program Structure](#program-structure)
* [Authors](#authors)


## About the Program
Program dengan GUI ini akan mengimplementasikan BFS dan DFS untuk mendapatkan rute untuk memperoleh seluruh treasure atau harta karun yang ada di dalam sebuah maze. Pencarian harta karun dimulai dari K (titik awal) dan diakhiri di titik T (tempat harta karun). Langkah yang digunakan dalam pencarian rute menggunakan prioritas RDUL (Right-Down-Up-Left). Program dapat menerima dan membaca input sebuah file txt yang berisi maze yang akan ditemukan solusi rute mendapatkan treasure-nya dengan algoritma DFS dan BFS. Pada saat memvisualisasikan gridnya, program akan menampilkan maze awal dengan deskripsi :
 - grid berwarna biru : titik awal pencarian harta karun
 - grid berwarna hijau : harta karun
 - grid berwarna hitam : grid yang tidak dapat dilewati
 - grid berwarna putih  : grid yang dapat dilewati untuk mendapatkan harta karun

Setelah mengeklik visualize, program akan menampilkan maze hasil dengan deskripsi :

 - grid berwarna kuning  : grid yang dilewati untuk mendapatkan harta karun
 - grid berwarna hitam :  grid yang tidak dapat dilewati
 - grid berwarna putih : grid yang tidak dilewati untuk mendapatkan harta karun.


## Requirements
Untuk dapat menjalankan program ini, maka pastikan perangkat sudah dilengkapi oleh aplikasi berikut :

1. [Visual Studio](https://visualstudio.microsoft.com/)
2. [C#](https://www.microsoft.com/en-us/download/details.aspx?id=7029)
3. [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)
4. [.Net Core 3.1: Link tersedia pada panduan](https://docs.google.com/document/d/1Ym2KomFPLIG_KAbm3A0bnhw4_XQAsOKzpTa70IgnLNU/edit#)


## Build Program
To build the Maze Solver program, follow these steps:

1. Clone this repository
2. Open Visual Studio 2022 and navigate to the cloned repository.
3. Open the solution file `TESTING.sln` in Visual Studio.
4. From the top toolbar, click on `Build` and then select `Build Solution`.
5. After the build process is complete, your executable file should be located in the `./bin` directory. Look for `TESTING.exe` in that directory.

## Run Program
To run the Maze Solver program, follow these steps:

1. Clone this repository
2. Build the executable by following the above instructions.
3. Open the `./bin/Debug/TESTING.exe` file.
4. Select your maze file `sampel-1.txt`
5. Select either `DFS` or `BFS` for your maze algorithm
6. Click on `Visualize` to display the maze.
7. Click on `Search` to display the solution.


## Program Structure
```
Tubes2_krustycrew                                           
├─ krustycrew                                               
│  └─ bin                                                   
│     └─ Debug                                              
├─ TESTING                                                  
│  ├─ bin                                                   
│  │  └─ Debug                                              
│  │     ├─ TESTING.exe                                     
│  │     └─ TESTING.pdb                                     
│  ├─ doc                                                   
│  │  └─ Tubes2_K3_13521013_Krustycrew.pdf                  
│  ├─ obj                                                   
│  │  ├─ Debug                                              
│  │  │  ├─ TempPE                                          
│  │  │  │  └─ Properties.Resources.Designer.cs.dll         
│  │  │  ├─ DesignTimeResolveAssemblyReferences.cache       
│  │  │  ├─ DesignTimeResolveAssemblyReferencesInput.cache  
│  │  │  ├─ TESTING.csproj.AssemblyReference.cache          
│  │  │  ├─ TESTING.csproj.CoreCompileInputs.cache          
│  │  │  ├─ TESTING.csproj.FileListAbsolute.txt             
│  │  │  ├─ TESTING.csproj.GenerateResource.cache           
│  │  │  ├─ TESTING.csproj.SuggestedBindingRedirects.cache  
│  │  │  ├─ TESTING.exe                                     
│  │  │  ├─ TESTING.Form1.resources                         
│  │  │  ├─ TESTING.pdb                                     
│  │  │  └─ TESTING.Properties.Resources.resources          
│  │  └─ Release                                            
│  │     └─ TESTING.csproj.AssemblyReference.cache          
│  ├─ Properties                                            
│  │  ├─ AssemblyInfo.cs                                    
│  │  ├─ Resources.Designer.cs                              
│  │  ├─ Resources.resx                                     
│  │  ├─ Settings.Designer.cs                               
│  │  └─ Settings.settings                                  
│  ├─ Resources                                             
│  │  ├─ 221.png                                            
│  │  ├─ crustycrewgui.png                                  
│  │  └─ newwww1.png                                        
│  ├─ src                                                   
│  │  ├─ App.config                                         
│  │  ├─ BFS.cs                                             
│  │  ├─ DFS.cs                                             
│  │  ├─ Form1.cs                                           
│  │  ├─ Form1.Designer.cs                                  
│  │  ├─ Form1.resx                                         
│  │  ├─ Map.cs                                             
│  │  └─ Program.cs                                         
│  ├─ test                                                  
│  │  ├─ sampel-1.txt                                       
│  │  ├─ sampel-2.txt                                       
│  │  ├─ sampel-3.txt                                       
│  │  ├─ sampel-4.txt                                       
│  │  └─ sampel-5.txt                                       
│  ├─ BFS.cs                                                
│  ├─ DFS.cs                                                
│  ├─ Form1.cs                                              
│  ├─ Form1.Designer.cs                                     
│  ├─ Form1.resx                                            
│  ├─ Map.cs                                                
│  ├─ Program.cs                                            
│  ├─ TESTING.csproj                                        
│  └─ TESTING.csproj.user                                   
├─ README.md                                                
└─ TESTING.sln                                              

```                                      


## Authors
```
13521014 - Muhhamad Syauqi Jannatan
13521013 - Eunice Sarah Siregar	
13521030 - Jauza Lathifah Annassalafi
```