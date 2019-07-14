# Projeto Processo Seletivo GDP

## Tema

Endless Runner, Dungeon Crawler, Rogue-Like                          
A ideia é que, assim como em um rogue-like, o jogador tente sobreviver o máximo possível enquanto progride no jogo. No caso ele estará descendo de andar em andar em um Dungeon, como em um dungeon crawler.                   
Durante o percurso para o próximo andar o jogador terá que enfrentar todo tipo de inimigo e armadilha para dificultar seu caminho, sem contar que terá que achar o caminho para o próximo andar.


## Mecânicas
1. **Movimentação** :    
  O jogador poderá escolher em qual direção vai, esquerda, direita, cima, baixo e também poderá escolher pular:
  
  ![alt text](https://github.com/noc1243/GDP_PPI/blob/master/Git_Documentation/image1.png)
  
2. **Armadilhas** :        
  O jogador encontrará armadilhas que terá que evitar em sua travessia, como buracos:

  ![alt text](https://github.com/noc1243/GDP_PPI/blob/master/Git_Documentation/image2.png)
  
  Nessa situação o jogador terá que pular para evitar que caia no buraco.

3. **Vida** :      
  Diferente de endless-runners normais, ser atingido por uma armadilha não significa game-over. Nessa situação o jogador perde um pouco de seu HP. Quando o HP chegar em zero o jogador recebe game-over

4. **Itens** :
  Para recompensar o jogador que decidir por arriscar e explorar mais um andar, o mesmo poderá encontrar itens, como poções para recuperar HP.
  
5. **Inimigos** :
  Além de armadilhas, também existirão inimigos que tentarão matar o jogador com seus ataques. Quando o jogador bater de frente com um inimigo, o mesmo será derrotado. 
  
  ![alt text](https://github.com/noc1243/GDP_PPI/blob/master/Git_Documentation/image3.png)
  
  Nessa imagem, pode-se observar um inimigo em azul disparando um ataque, em amarelo, contra o jogador. Para desviar de tal ataque o jogador terá que pular na hora certa até alcançar o inimigo.
  
6. **Experiência** :
  Ao derrotar inimigos o jogador receberá pontos de experiência. Quando alcançado um certo limiar, ele subirá de level, ganhando assim mais hp e defesa contra o ataque de inimigos e danos de armadilha. Além disso, todo seu HP será recuperado ao passar de level.
  
7. **Tempo** :
  Como mecânica experimental, estuda-se colocar um limite de tempo para que o jogador complete um andar. Caso esse limite de tempo não seja cumprido, ele receberá game-over. Essa mecânica traz um senso enorme de risco recompensa, visto que, ao explorar mais um andar, é possível que o jogador encontre itens que facilitem no resto de sua jornada.
  
8. **Travas** :
  Existirão portas que o jogador terá que passar que necessitarão de chaves para serem transpostas. Essas chaves ficarão escondidas no andar e deverão ser encontradas pelo jogador durante sua exploração. 
  
9. **Procedural** :
  Os andares serão gerados de forma procedural, garantindo que o jogador nunca se canse de jogar.
  
## Plataforma alvo
Android. A maior parte da movimentação foi pensada de forma a fazer com que o jogo possa ser jogado de um celular a partir apenas do touch.

## Objetivo do Projeto
Em grande parte dos jogos de celular, observa-se que os jogos têm como objetivo apenas viciar e distrair o jogador com suas mecânicas. O grande objetivo desse jogo é conseguir trazer essas mesmas mecânicas para um contexto de rogue-like e dungeon crawler, onde, a todo momento jogadores têm que tomar decisões que afetarão todo o resto da sessão de jogo.             
Dessa forma, o grande objetivo é criar um rogue-like/dungeon crawler que possa ser casual o suficiente para que qualquer pessoa possa jogar e que, ao mesmo tempo, não perca a essência desses gêneros.

## Escopo do Projeto
Como o tempo limite do projeto é de menos de duas semanas e que só uma pessoa trabalhará no jogo, estima-se o seguinte workflow para um MVP:

1. Implementar movimentação do jogador;
1. Implementar barra de HP do jogador;
1. Implementar armadilhas;
1. Implementar inimigos;
1. Implementar itens;
1. Implementar pontos de experiência;
1. Criar um level não procedural para ser jogado.

Acredita-se que, no máximo, será possível implementar um ou dois tipos de inimigo diferentes, 1 ou 2 tipos de armadilha diferentes, 1 ou 2 tipos de itens diferentes no MVP dependendo de quão bem o projeto irá progredir.                    
Para um MVP de 2 semanas é impossível implementar um código de geração procedural de andares, logo, para o mesmo, apenas um andar fixo será criado. 


