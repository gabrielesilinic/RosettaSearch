def genTrigrams(kw, unique=True):
    kw.replace(' ','')
    word=kw
    word=' '+kw.lower().strip()+' '
    tgrams=[]
    for i in range(0,len(word),1):
        if not (unique and (word[i:i+3] in tgrams)):
            tgrams.append(word[i:i+3])
    if ' ' in tgrams:
        tgrams.remove(' ')
    return tgrams

def tsearch(query,word):
    t1=genTrigrams(word,unique=False)
    t2=genTrigrams(query)
    c=0
    for i in t2:
        c=c+t1.count(i)
    return c/len(t1)

