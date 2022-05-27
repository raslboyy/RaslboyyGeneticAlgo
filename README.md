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

![ezgif-2-43a74b66d2](https://user-images.githubusercontent.com/33222839/169856157-a6310aed-fc11-49cb-ab14-6a78c6e7baea.gif)

--------

![ezgif-2-e170e853f6](https://user-images.githubusercontent.com/33222839/169855735-d9d0c518-7c14-4a94-be3f-0b70595f6328.gif)

# Анализ
## Бенчмарки
|  Method | PopulationSize | KillRate | RandomSurviveRate |       Mean |       Error |    StdDev |    Gen 0 |    Gen 1 | Allocated |
|-------- |--------------- |--------- |------------------ |-----------:|------------:|----------:|---------:|---------:|----------:|
| Solving |            100 |      0.6 |               0.1 | 1,518.6 us |   506.45 us |  27.76 us |  70.3125 |  23.4375 |    320 KB |
| Solving |            100 |      0.6 |               0.2 | 1,888.3 us |    62.52 us |   3.43 us |  83.9844 |  39.0625 |    438 KB |
| Solving |            100 |      0.7 |               0.1 | 1,901.0 us |   156.61 us |   8.58 us |  82.0313 |  41.0156 |    496 KB |
| Solving |            100 |      0.7 |               0.2 | 1,433.4 us | 2,501.28 us | 137.10 us |        - |        - |    323 KB |
| Solving |            100 |      0.8 |               0.1 | 1,481.7 us |   386.73 us |  21.20 us |  78.1250 |  31.2500 |    374 KB |
| Solving |            100 |      0.8 |               0.2 | 1,658.6 us |   294.77 us |  16.16 us |  80.0781 |  37.1094 |    415 KB |
| Solving |            500 |      0.6 |               0.1 |   407.6 us |   178.99 us |   9.81 us |  57.1289 |   1.9531 |    235 KB |
| Solving |            500 |      0.6 |               0.2 | 7,024.4 us |   720.90 us |  39.52 us |        - |        - |  __1,504 KB__ |
| Solving |            500 |      0.7 |               0.1 | 6,988.9 us | 3,145.44 us | 172.41 us |        - |        - |  1,606 KB |
| Solving |            500 |      0.7 |               0.2 |   690.9 us |    85.31 us |   4.68 us |  69.3359 |  22.4609 |    285 KB |
| Solving |            500 |      0.8 |               0.1 |   892.3 us |   251.11 us |  13.76 us |        - |        - |    310 KB |
| Solving |            500 |      0.8 |               0.2 | 6,449.9 us | 1,685.71 us |  92.40 us | 257.8125 | 125.0000 |  1,596 KB |
| Solving |           1000 |      0.6 |               0.1 | 1,035.6 us |   352.57 us |  19.33 us |        - |        - |    523 KB |
| Solving |           1000 |      0.6 |               0.2 |   812.5 us |   856.94 us |  46.97 us |        - |        - |    470 KB |
| Solving |           1000 |      0.7 |               0.1 | 1,327.5 us |   510.44 us |  27.98 us |        - |        - |    517 KB |
| Solving |           1000 |      0.7 |               0.2 | 1,309.4 us |   586.02 us |  32.12 us |        - |        - |    517 KB |
| Solving |           1000 |      0.8 |               0.1 | 1,760.9 us |   336.60 us |  18.45 us |        - |        - |    617 KB |
| Solving |           1000 |      0.8 |               0.2 | 1,560.4 us |   785.14 us |  43.04 us |        - |        - |    564 KB |
## dotTrace
`PopulationSize = 500 KillRate = 0.6 RandomSurviveRate = 0.2`
