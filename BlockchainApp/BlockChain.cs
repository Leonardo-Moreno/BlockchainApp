using System;
using System.Collections.Generic;
using System.Text;

namespace BlockchainApp
{
    class BlockChain
    {
        public class Blockchain
        {
            public IList<Block> Chain { set; get; }

           public Blockchain()
            {
                InitializeChain();
                AddGenesisBlock();
            }


            public void InitializeChain()
            {
                Chain = new List<Block>();
            }

            public Block CreateGenesisBlock()
            {
                return new Block(DateTime.Now, null, "{The Times, 03/jan/2009: Chanceler à beira da segunda recuperação financeira dos bancos}");
            }

            public void AddGenesisBlock()
            {
                Chain.Add(CreateGenesisBlock());
            }

            public Block GetLatestBlock()
            {
                return Chain[Chain.Count - 1];
            }

            public void AddBlock(Block block)
            {
                Block latestBlock = GetLatestBlock();
                block.Index = latestBlock.Index + 1;
                block.PreviousHash = latestBlock.Hash;
                block.Hash = block.CalculateHash();
                Chain.Add(block);
            }

            //função responsavel por validar o bloco atual eo bloco anteriror
            public bool IsValid()
            {
                for (int i = 1; i < Chain.Count; i++)
                {
                    Block currentBlock = Chain[i];
                    Block previousBlock = Chain[i - 1];

                    if (currentBlock.Hash != currentBlock.CalculateHash())
                    {
                        return false;
                    }

                    if (currentBlock.PreviousHash != previousBlock.Hash)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
