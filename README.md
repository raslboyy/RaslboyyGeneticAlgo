# RaslboyyGeneticAlgo

### Стадии
- Отбор
    - Оценка особей
    - Исключение слабых особей
    - Выживание рандомной группы слабых особей
- Скрещивание
- Мутация

--------
![ezgif-2-66a6c1ed87](https://user-images.githubusercontent.com/33222839/169855987-87ace248-5cee-413d-af0c-09acd9d89796.gif)

--------

![MainWindow 2022-06-12 15-35-32](https://user-images.githubusercontent.com/33222839/173233630-4231bd09-6cbe-48fb-a82e-0775e84af360.gif)

--------

![MainWindow 2022-06-12 15-34-32](https://user-images.githubusercontent.com/33222839/173233662-c7a43ec7-4669-4313-aff4-ceb3123a4acf.gif)

--------

![MainWindow 2022-06-12 15-33-48](https://user-images.githubusercontent.com/33222839/173233680-9ba64186-9e8d-4a30-bd49-87228c2341ef.gif)

--------

# Анализ
## Бенчмарки
|  Method | PopulationSize | KillRate | RandomSurviveRate |         Mean |          Error |         StdDev |       Median |    Gen 0 |    Gen 1 | Allocated |
|-------- |--------------- |--------- |------------------ |-------------:|---------------:|---------------:|-------------:|---------:|---------:|----------:|
| Solving |            100 |      0.6 |               0.1 |  1,944.63 us |      49.198 us |      29.277 us |  1,954.30 us |        - |        - |    440 KB |
| Solving |            100 |      0.6 |               0.2 |     78.99 us |       2.500 us |       1.654 us |     79.21 us |  12.0850 |        - |     49 KB |
| Solving |            100 |      0.7 |               0.1 |  3,416.55 us |     357.312 us |     236.340 us |  3,325.30 us |        - |        - |    345 KB |
| Solving |            100 |      0.7 |               0.2 |  1,696.69 us |     152.026 us |     100.556 us |  1,662.90 us |        - |        - |    344 KB |
| Solving |            100 |      0.8 |               0.1 |  1,635.81 us |      25.177 us |      16.653 us |  1,635.82 us |  76.1719 |  33.2031 |    373 KB |
| Solving |            100 |      0.8 |               0.2 |  1,757.73 us |       9.153 us |       4.787 us |  1,757.88 us |  78.1250 |  31.2500 |    402 KB |
| Solving |            500 |      0.6 |               0.1 |    425.81 us |       5.714 us |       3.400 us |    427.13 us |  57.1289 |   1.9531 |    235 KB |
| Solving |            500 |      0.6 |               0.2 |    421.80 us |       5.218 us |       3.451 us |    422.15 us |  57.1289 |   1.9531 |    235 KB |
| Solving |            500 |      0.7 |               0.1 |  7,561.98 us |      94.035 us |      55.959 us |  7,564.84 us | 250.0000 | 125.0000 |  1,600 KB |
| Solving |            500 |      0.7 |               0.2 |    816.61 us |     109.558 us |      72.466 us |    786.29 us |  69.3359 |  22.4609 |    285 KB |
| Solving |            500 |      0.8 |               0.1 |    864.33 us |      24.338 us |      14.483 us |    866.00 us |        - |        - |    283 KB |
| Solving |            500 |      0.8 |               0.2 |    858.57 us |      31.306 us |      18.630 us |    855.90 us |        - |        - |    283 KB |
| Solving |           1000 |      0.6 |               0.1 | 89,603.57 us | 186,244.877 us | 110,831.339 us | 14,846.40 us |        - |        - |  2,890 KB |
| Solving |           1000 |      0.6 |               0.2 |  1,080.58 us |      98.059 us |      51.287 us |  1,062.20 us |        - |        - |    523 KB |
| Solving |           1000 |      0.7 |               0.1 |  1,550.61 us |     140.831 us |      93.151 us |  1,550.60 us |        - |        - |    570 KB |
| Solving |           1000 |      0.7 |               0.2 |  1,324.42 us |      80.003 us |      41.843 us |  1,304.00 us |        - |        - |    517 KB |
| Solving |           1000 |      0.8 |               0.1 |  1,708.33 us |     127.715 us |      76.001 us |  1,710.30 us |        - |        - |    564 KB |
| Solving |           1000 |      0.8 |               0.2 | 15,158.08 us |     334.475 us |     199.041 us | 15,137.70 us |        - |        - |  3,436 KB |
## dotTrace
`PopulationSize = 500 KillRate = 0.6 RandomSurviveRate = 0.2`
![image](https://user-images.githubusercontent.com/33222839/170613636-759909a6-45d9-461c-b47a-2b3b6c74298a.png)

# Проблемы
## Аллокации массивов
- Использовать capacity - бесполезно т.к. мы не знаем какой массив "выживет"
- Использовать ArrayPool

![image](https://user-images.githubusercontent.com/33222839/170626500-181a1b31-573b-444f-872b-5f2a50c559e1.png)
[PR](https://github.com/is-tech-y24-1/RaslboyyGeneticAlgo/pull/1)

- Костыли
![image](https://user-images.githubusercontent.com/33222839/170632756-cf1b6c74-11c5-4e26-9c56-4f83d33fd683.png)
[PR](https://github.com/is-tech-y24-1/RaslboyyGeneticAlgo/pull/2)

![image](https://user-images.githubusercontent.com/33222839/170634728-dbbbd54b-2239-441c-a664-a30c03be7eca.png)

# Результирующие бенчмарки
|  Method | PopulationSize | KillRate | RandomSurviveRate |       Mean |       Error |      StdDev |   Gen 0 |   Gen 1 | Allocated |
|-------- |--------------- |--------- |------------------ |-----------:|------------:|------------:|--------:|--------:|----------:|
| Solving |            100 |      0.6 |               0.1 | 1,381.0 us |   157.90 us |    82.58 us |       - |       - |     11 KB |
| Solving |            100 |      0.6 |               0.2 | 2,208.6 us |    36.50 us |    24.14 us |       - |       - |     11 KB |
| Solving |            100 |      0.7 |               0.1 | 2,138.3 us |    27.69 us |    16.48 us | 11.7188 |  3.9063 |     76 KB |
| Solving |            100 |      0.7 |               0.2 | 1,831.6 us |    83.05 us |    49.42 us |       - |       - |     46 KB |
| Solving |            100 |      0.8 |               0.1 | 1,774.5 us |    66.31 us |    43.86 us | 15.6250 |       - |     83 KB |
| Solving |            100 |      0.8 |               0.2 | 2,291.8 us |   268.57 us |   177.64 us | 23.4375 | 11.7188 |    146 KB |
| Solving |            500 |      0.6 |               0.1 |   623.9 us |     8.57 us |     5.67 us | 10.7422 |  0.9766 |     48 KB |
| Solving |            500 |      0.6 |               0.2 |   766.2 us |    65.13 us |    38.75 us | 10.7422 |  0.9766 |     48 KB |
| Solving |            500 |      0.7 |               0.1 | 6,718.3 us |   109.78 us |    57.42 us | 31.2500 | 15.6250 |    218 KB |
| Solving |            500 |      0.7 |               0.2 | 9,324.7 us | 1,706.61 us | 1,128.82 us | 31.2500 | 15.6250 |    218 KB |
| Solving |            500 |      0.8 |               0.1 | 7,190.5 us |   825.11 us |   431.55 us | 62.5000 | 31.2500 |    392 KB |
| Solving |            500 |      0.8 |               0.2 | 7,461.0 us |   120.66 us |    79.81 us |       - |       - |    393 KB |
| Solving |           1000 |      0.6 |               0.1 | 1,987.6 us |    37.75 us |    19.74 us |       - |       - |     96 KB |
| Solving |           1000 |      0.6 |               0.2 | 2,024.5 us |    55.35 us |    32.94 us |       - |       - |     96 KB |
| Solving |           1000 |      0.7 |               0.1 | 2,089.9 us |    34.41 us |    20.47 us |       - |       - |    143 KB |
| Solving |           1000 |      0.7 |               0.2 | 2,226.7 us |    79.26 us |    47.17 us |       - |       - |    143 KB |
| Solving |           1000 |      0.8 |               0.1 | 2,427.8 us |   139.41 us |    72.92 us |       - |       - |    190 KB |
| Solving |           1000 |      0.8 |               0.2 | 2,581.8 us |   151.64 us |    90.24 us |       - |       - |    190 KB |
