# Scenario: `GET single person`

- Duration: `00:00:10`
- RPS: `468`
- Concurrent Copies: `1`

| __step__                 | __details__                                                             |
|--------------------------|-------------------------------------------------------------------------|
| name                     | `init`                                                                  |
| request count            | all = `4687`, OK = `4687`, failed = `0`                                 |
| response time            | RPS = `468`, min = `0`, mean = `1`, max = `1629`                        |
| response time percentile | 50% = `1`, 75% = `2`, 95% = `3`, StdDev = `25`                          |
| data transfer            | min = `0.050 Kb`, mean = `0.050 Kb`, max = `0.050 Kb`, all = `0.240 MB` |