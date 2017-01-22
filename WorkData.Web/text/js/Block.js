
function Block(dom, option) {
    this.dom = dom; //dom
    this.parentW = this.dom.parentNode.clientWidth;
    this.parentH = this.dom.parentNode.clientHeight;
    this.scale = 1.5; //黑块 宽高比
    this.h = parseInt(this.parentW / 3 * this.scale);
    this.top = -this.h;
    this.speed = 2; //速度
    this.speedLevel = 40;//xx分一个速度等级 即xx分变速一次
    this.maxSpeed = 20; //最大速度
    this.timer = null; //定时器
    this.timeCount = 15000;//游戏时长
    this.state = true; //游戏判断
    this.maxScore = 1;//最大分数
    this.sum = 0; //分数
    this.bombChanges = 20;//炸弹概率 总是100
    this.markelement = null;
    $.extend(this, option);
    this.canPrize = true;
    this.result = [];
    this.gameCount = 1; //剩余游戏次数
}

Block.prototype.init = function () {

    var pThis = this;

    pThis.zsy();
    pThis.mark();
    //pThis.initAudio();

    var clickEvent = "ontouchstart" in document.documentElement ? "touchstart" : "click";

    pThis.dom.addEventListener(clickEvent, function (e) {

        if (!pThis.state) {
            return false;
        }
        e = e || window.event;
        var target = e.target || e.srcElement;

        if ((target.className.indexOf('block') !== -1 || target.className.indexOf('bomb') !== -1) &&
            target.className.indexOf('active') === -1) {//正确点击红包

            if (target.className.indexOf('block') !== -1) {
                pThis.sum += parseInt(target.id);
                target.className = target.className + '_click active';
                target.innerHTML = '+1';
            } else {
                if (pThis.sum>2) {
                    pThis.sum -= 2;
                }else {
                    pThis.sum = 0;
                }
                target.className = target.className.replace(' block', ' bomb');
                target.innerHTML = '炸弹';
            }
            target.className = target.className + '_click active';
        }
    });
}

Block.prototype.initAudio = function () {
    this.i = 1;//god-audio
    this.j = 1;//bomb-radio
}

//创建一行，，，
Block.prototype.addRow = function () {

    var s = Math.floor(Math.random() * 4);
    var b = Math.floor(Math.random() * 100);
    var score = 1;//Math.floor(Math.random() * 10 + 3);
    var className = b < this.bombChanges ?
        ("rb-cell rb-cell-default rb-cell-" + s + " bomb")
        : ("rb-cell rb-cell-default rb-cell-" + s + " block");
    var oCell = document.createElement('div');
    oCell.className = className;
    oCell.id = b < this.bombChanges ? "炸弹" : score;
    var fChild = this.dom.firstChild;
    if (fChild == null) {
        this.dom.appendChild(oCell);
    } else {
        this.dom.insertBefore(oCell, fChild);

    }
}

//判断什么时候拉回top 什么时候提升速度，，，什么时候停止
Block.prototype.clear = function () {
    var pthis = this;

    $('.rb-cell').each(function () {
        if ($(this).offset().top === pthis.parentH) {
            var $this = $(this);
            setTimeout(function () {
                $this.remove();
            }, 5000);
        }
    });
}

//移动
Block.prototype.move = function () {
    this.top += this.speed;
    this.dom.style.top = this.top + 'px';
}

//分数
Block.prototype.mark = function () {
    var oMark = document.createElement("div");
    oMark.className = "mark";
    oMark.innerHTML = this.sum;
    this.dom.parentNode.appendChild(oMark);
    this.markelement = $(oMark);
}

//元素自适应
Block.prototype.zsy = function () {
    var pThis = this;
    if ("ontouchstart" in document.documentElement) {
        pThis.dom.parentNode.className = "ph-main";
    }
}

//游戏开始
Block.prototype.start = function () {

    var pThis = this;

    var currentTime = 0;
    pThis.timer = setInterval(function () {
        if (currentTime < pThis.timeCount && pThis.sum < pThis.maxScore) {
            //pThis.clear();
            pThis.addRow();
            currentTime += 400;
            var tt = (pThis.timeCount - currentTime) >= 0 ? (pThis.timeCount - currentTime) : 0;//剩余时间
            pThis.markelement.html(parseInt(tt / 1000));
        }
        else {
            pThis.gameOver();
        }
    }, 400);
}

//游戏结束  
Block.prototype.gameOver = function () {
    this.state = false;
    clearInterval(this.timer);
    this.end();
    return false;
}

//游戏重来
Block.prototype.end = function () {
    //<label>游戏结束</label><br />
    //<img src="img/gameover.png" />
    $(this.dom).append('<div id="gameover">' + this.sum + '</div>');
}

//#region 音频处理
function createContext() {
    window.AudioContext = (window.AudioContext || window.webkitAudioContext);
    if (window.AudioContext) {
        var context = new window.AudioContext();
        return context;
    } else {
        console.log('not support web audio api');
        return null;
    }
}

function createSource(audioUrl) {
    var context = createContext();
    var audio = window.audio = {};
    audioUrl = './audio/god.mp3'; // 音频文件URL
    var xhr = new XMLHttpRequest();
    xhr.open('GET', audioUrl, true);
    xhr.responseType = 'arraybuffer';
    xhr.onload = function () {
        context.decodeAudioData(request.response, function (buffer) {
            var source = context.createBufferSource();
            source.buffer = buffer;
            source.connect(context.destination);
            source.start(); // 播放.

            // 下面 会用到这个
            window.audio.buffer = buffer;
        });
    }
    xhr.send();
}

function start() {
    var bufferSource = audio.context.createBufferSource();
    bufferSource.buffer = window.audio.buffer;
    bufferSource.buffer.connect(audio.context.destination);
    bufferSource.loop = false;
    bufferSource.start();
}

//#endregion