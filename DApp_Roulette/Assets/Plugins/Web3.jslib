const getBalance = async function(){
    let balance = await web3.eth.getBalance(web3.currentProvider.selectedAddress);
    gameInstance.SendMessage("[Listener]","UpdateBalance", balance)
}

const login = async function(){
    await connectWeb3();
    let address = ethereum.selectedAddress;
    if(address === undefined){
        gameInstance.SendMessage("[Listener]","OnLoginFail");
    }
    else{
        console.log(gameInstance)
        gameInstance.SendMessage("[Listener]","OnLoginSuccess");
        let balance = await web3.eth.getBalance(web3.currentProvider.selectedAddress);
        console.log(balance, address)
        gameInstance.SendMessage("[Listener]","OnBalance", balance);
        gameInstance.SendMessage("[Listener]","OnAddress", address);
    }
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

mergeInto(LibraryManager.library, {getBalance, login, fromWei})
