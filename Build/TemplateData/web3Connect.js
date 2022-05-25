async function connectWeb3() {
  if (window.ethereum) {
    web3 = new Web3(window.ethereum);
    // connect popup
    await ethereum.enable();
  }
}
