namespace OKDeck {
	enum Suit {Diamonds,Hearts,Cubs,Spades};
	enum Rank {A,_2,_3,_4,_5,_6,_7,_8,_9,_10,J,Q,K};
	struct Card {
		public Rank rank {get;set;}
		public Suit suit {get;set;}
		
		public Card( Rank r=Rank.A,Suit s=Suit.Hearts):this() // call default constructor; C# idiosyncracy
		{
			rank=r;
			suit=s;
		}
	  public override string ToString()
	  {
	    return "Card("+rank+" of "+suit+")";
	  }
	};

  class Deck{
    Card[] cards=new Card[52];

    public Deck()
    {
      Initialize();
    }
    private void Initialize() 
    {
      int place=0;
        foreach(Rank r in Rank.GetValues(typeof(Rank))){
	  foreach(Suit s in Suit.GetValues(typeof(Suit))) {
	    cards[place]=new Card(r,s);										  			 
	    ++place;
	  }
	}
    }

    private void swapCards(int place1, int place2)
    {
      Card tmp=cards[place1];
      cards[place1]=cards[place2];
      cards[place2]=tmp;
    }

    public void shuffle()
    {
      System.Random r=new System.Random();
      for(int i=0; i<2*cards.Length; ++i)
	{
	  int place1=r.Next(cards.Length);
	  int place2=r.Next(cards.Length);
	  swapCards(place1,place2);
	}
    }
    
    public System.Collections.Generic.IEnumerable<Card> getCards()
    {
      foreach(Card c in cards)
	yield return c;
    }
  }

  class TheMain {
	static void Main(string[] args) {
	  Deck d=new Deck();
	  foreach(Card c in d.getCards())
	    {
	      System.Console.WriteLine(c);
	    }
	  d.shuffle();
	  System.Console.WriteLine("   ----------  ------");
	  foreach(Card c in d.getCards())
	    {
	      System.Console.WriteLine(c);
	    }

	}
  }
};
