const getBalance = async function(){
    let balance = await web3.eth.getBalance(web3.currentProvider.selectedAddress);
    gameInstance.SendMessage("[Listener]","UpdateBalance", balance)
}

const login = async function(){
    connectWeb3().then(()=>{
        window.contract = new web3.eth.Contract(abi, "0x4dB0aEe809f066acdCfdcE1f62b9b848556DC869");
        console.log(gameInstance)
        gameInstance.SendMessage("OnLogin","OnLoginSuccess");
        let address = ethereum.selectedAddress;
        web3.eth.getBalance(web3.currentProvider.selectedAddress).then(balance=>{
            console.log(balance, address)
            gameInstance.SendMessage("OnUser","OnBalance", balance);
            gameInstance.SendMessage("OnUser","OnAddress", address);
        })
    }).catch(err=>
        gameInstance.SendMessage("OnLogin","OnLoginFail")
    )

}

const fromWei = function(wei){
    wei = UTF8ToString(wei);
    console.log(wei, typeof wei)
    let ether =  web3.utils.fromWei(wei, "ether")
    ether = ether.toString();
    let bufferSize = lengthBytesUTF8(ether)+1;
    let buffer = _malloc(bufferSize);
    stringToUTF8(ether, buffer, bufferSize);
    return buffer;
}

const toWei = function(ether){
    ether = UTF8ToString(ether);
    console.log(ether)
    let wei = web3.utils.toWei(ether, "ether")
    wei = wei.toString()
    let bufferSize = lengthBytesUTF8(wei)+1;
    let buffer = _malloc(bufferSize);
    stringToUTF8(wei, buffer, bufferSize);
    return buffer;
}

const bet = async function(bettingValue, bettingType){
    bettingValue = UTF8ToString(bettingValue)
    callBet(bettingValue, bettingType).once('transactionHash', function(hash){ 
        console.log(hash)
        gameInstance.SendMessage("OnBetResult", "OnBet");
    }).then(receipt=>{
        console.log(receipt)
        let blockNumber = receipt.blockNumber
        let rawData = receipt.events.Bet.raw.data
        let requestId = '0x' + rawData.substring(rawData.length-64)
        console.log(requestId)
        web3.eth.subscribe('logs', {
            fromBlock: blockNumber,
            address: "0x6168499c0cFfCaCD319c818142124B7A15E857ab",
            topics:[
                "0x7dffc5ae5ee4e2e4df1651cf6ad329a73cebdb728f37ea0187b9b17e036756e4",
                requestId
            ]
        }).on("data", function(log){
            callReveal().then(async receipt=>{
                let balance = await web3.eth.getBalance(web3.currentProvider.selectedAddress)
                console.log(receipt)
                let prize = receipt.events.Reveal.returnValues.prize
                let betAmount = receipt.events.Reveal.returnValues.betAmount
                console.log(prize, betAmount)
                if(prize === "0"){
                    console.log("OnBetResult", "OnResult", "-" + betAmount);
                    gameInstance.SendMessage("OnBetResult", "OnResult", balance);
                }
                else{
                    console.log("OnBetResult", "OnResult", "-" + betAmount);
                    gameInstance.SendMessage("OnBetResult", "OnResult", balance);
                }
                gameInstance.SendMessage("OnUser","OnBalance", balance)
            })
        })
    })


}
mergeInto(LibraryManager.library, {getBalance, login, fromWei, toWei, bet})
